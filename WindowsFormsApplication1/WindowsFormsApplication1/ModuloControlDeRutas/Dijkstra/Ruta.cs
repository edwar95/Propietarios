using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dijkstra
{
    [Serializable]
    public enum GraphType
    {
        Undirected = 0,
        Directed = 1,
    }

    public class BinaryNode : IComparable<BinaryNode>
    {
        public Node Nodo;
        public int Distancia;

        public BinaryNode (Node nodo, int distancia)
        {
            this.Nodo = nodo;
            this.Distancia = distancia;
        }
        public int CompareTo(BinaryNode nodo)
        {
           
            if (this.Distancia > nodo.Distancia)
                return 1;
            if (this.Distancia < nodo.Distancia)
                return -1;
            else
                return 0;
        }
    }
    [Serializable]
    public class Ruta
    {
        private int _nextId = 0;
        public Dictionary<int, Node> Nodes { get; set; }
        public GraphType Type { get; set; }

        public Ruta(GraphType type)
        {
            this.Nodes = new Dictionary<int, Node>();
            this.Type = type;
        }

        public Node AddNode(string nombre)
        {
            var nodo = new Node(_nextId, nombre);
            this.Nodes.Add(_nextId, nodo);
            _nextId++;
            return nodo;
        }

        public void AddAdyacencia(Node nodo, Node destino, int costo)
        {
            if(nodo.ListaAdyacencia.ContainsKey(destino))
                return;

            var edge = new Edge(costo);
            
            nodo.ListaAdyacencia.Add(destino, edge);

            if (this.Type == GraphType.Undirected)
            {
                if(!destino.ListaAdyacencia.ContainsKey(nodo))
                    destino.ListaAdyacencia.Add(nodo, edge);
            }
               
        }
        public void eliminarAdyacencia(Node nodo, Node destino)
        {
            if(!nodo.ListaAdyacencia.ContainsKey(destino))
                return;

            nodo.ListaAdyacencia.Remove(destino);

            if (this.Type == GraphType.Undirected)
                destino.ListaAdyacencia.Remove(nodo);
        }

        public string GetColorName(Color color)
        {
            if (color == Color.Red)
                return "red";
            if (color == Color.Yellow)
                return "yellow";
            if (color == Color.Green)
                return "green";
            if (color == Color.Blue)
                return "blue";
            if (color == Color.White)
                return "white";
            if (color == Color.Orange)
                return "orange";
            if (color == Color.Black)
                return "black";
                
            return "white";
        }

        public Node GetNodeById(int id)
        {
            if (!Nodes.ContainsKey(id))
                return null;

            return Nodes[id];
        }

        public Ruta Copy()
        {
            var graph = (Ruta)this.MemberwiseClone();

            graph.Nodes = new Dictionary<int, Node>();

            foreach (var nodo in Nodes)
            {
                var copyNode = nodo.Value.Copy();
                graph.Nodes.Add(nodo.Key, copyNode);
            }

            var edgeCache = new Dictionary<Edge, Edge>();

            foreach (var nodo in Nodes)
            {
                var copyNode = graph.GetNodeById(nodo.Key);

                foreach (var edge in nodo.Value.ListaAdyacencia)
                {
                    var destNode = graph.GetNodeById(edge.Key.GetId());

                    if (!edgeCache.ContainsKey(edge.Value))
                        edgeCache.Add(edge.Value, edge.Value.Copy());
                    copyNode.ListaAdyacencia.Add(destNode, edgeCache[edge.Value]);
                }
            }
            return graph;
        }

        public void ResetColors()
        {
            foreach (var nodo in Nodes)
            {
                nodo.Value.Color = Color.White;
                foreach (var edge in nodo.Value.ListaAdyacencia)
                {
                    edge.Value.Color = Color.Black;
                }
            }
        }

        public void Reset()
        {
            this._nextId = 0;
            this.Nodes.Clear();
        }

        private Node GetSmallestNode(IEnumerable<Node> nodos, Dictionary<Node,int> distancias )
        {
            var min = int.MaxValue;
            Node selected = null;

            foreach (var nodo in nodos)
            {
                if (distancias[nodo] >= min)
                    continue;

                min = distancias[nodo];
                selected = nodo;
            }

            return selected;
        }
        public List<Ruta> Dijkstra(Node nodoInicial, Node nodoFinal)
        {
            var steps = new List<Ruta>();
            steps.Add(this.Copy());

            if(this.Nodes.Any(e => e.Value.ListaAdyacencia.Any(f => f.Value.Costo < 0)))
                return new List<Ruta>();

            if (nodoFinal == nodoInicial)
            {
                nodoInicial.Color = Color.Orange;
                steps.Add(this.Copy());
                return steps;
            }

            var nodos = new List<Node>(Nodes.Values);
            var distancia = new Dictionary<Node,int>();
            var shortest = new Dictionary<Node, Node>();

            foreach (var node in Nodes)
            {
                distancia.Add(node.Value,int.MaxValue);
                shortest.Add(node.Value, null);
                node.Value.Color = Color.White;
            }

            distancia[nodoInicial] = 0;

            while (nodos.Count > 0)
            {
                var u = GetSmallestNode(nodos, distancia);

                if (u == null)
                    break;

                nodos.Remove(u);

                u.Color = Color.Blue;

                foreach (var v in u.ListaAdyacencia)
                {
                    if (distancia[v.Key] > distancia[u] + v.Value.Costo)
                    {
                        distancia[v.Key] = distancia[u] + v.Value.Costo;

                       if (shortest[v.Key] != null)
                            v.Key.ListaAdyacencia[shortest[v.Key]].Color = Color.Red;

                        shortest[v.Key] = u;

                        v.Value.Color = Color.Yellow;
                        
                        steps.Add(this.Copy());
                        
                        nodos.Add(v.Key);
                    }
                    
                }
                u.Color = Color.Orange;
            }

            Node aux = nodoFinal;

            if (shortest[aux] == null)
                return new List<Ruta>();
            
            while (aux != nodoInicial)
            {
                var edge = aux.ListaAdyacencia[shortest[aux]];
                aux.Color = Color.Blue;
                edge.Color = Color.Green;
                steps.Add(this.Copy());
                aux.Color = Color.Orange;
                aux = shortest[aux];
            }

            steps.Add(this.Copy());

            return steps;
        }

        public void DijkstraFibonacciHeap(Node startNode)
        {
            var nodos = new FibonacciHeap<Node>();
            var distancias = new Dictionary<Node, int>();
            var shortest = new Dictionary<Node, Node>();

            foreach (var nodo in Nodes)
            {
                distancias.Add(nodo.Value, int.MaxValue);
                shortest.Add(nodo.Value, null);
                nodos.Add(nodo.Value, int.MaxValue);
            }

            distancias[startNode] = 0;

            while (!nodos.IsEmpty())
            {
                var u = nodos.DequeueMin();

                if (u == null)
                    break;

                foreach (var v in u.ListaAdyacencia)
                {
                    if (distancias[v.Key] > distancias[u] + v.Value.Costo)
                    {
                        distancias[v.Key] = distancias[u] + v.Value.Costo;
                        shortest[v.Key] = u;
                       // nodes.Add(v.Key, distance[v.Key]);
                    }
                }
            } 
        }

        public void DijkstraDistanceVector(Node startNode)
        {
            var nodos = new List<Node>(Nodes.Values);
            var distancias = new Dictionary<Node, int>();
            var shortest = new Dictionary<Node, Node>();

            foreach (var nodo in Nodes)
            {
                distancias.Add(nodo.Value, int.MaxValue);
                shortest.Add(nodo.Value, null);
            }

            distancias[startNode] = 0;

            while (nodos.Count > 0)
            {
                var u = GetSmallestNode(nodos, distancias);

                if (u == null)
                    break;

                nodos.Remove(u);

                foreach (var v in u.ListaAdyacencia)
                {
                    if (distancias[v.Key] > distancias[u] + v.Value.Costo)
                    {
                        distancias[v.Key] = distancias[u] + v.Value.Costo; 
                        shortest[v.Key] = u;             
                        nodos.Add(v.Key);
                    }

                }               
            }  
        }
        public void DijkstraBinary(Node startNode)
        {
            var nodos = new BinaryHeap<BinaryNode>();
            var distancias = new Dictionary<Node, int>();
            var shortest = new Dictionary<Node, Node>();

            foreach (var nodo in Nodes)
            {
                distancias.Add(nodo.Value, int.MaxValue);
                shortest.Add(nodo.Value, null);
                if(nodo.Value != startNode)
                    nodos.Add(new BinaryNode(nodo.Value, int.MaxValue));
                else
                    nodos.Add(new BinaryNode(nodo.Value, 0));
            }

            distancias[startNode] = 0;

            while (nodos.Count > 0)
            {
                var u = nodos.Remove();

                if (u == null)
                    break;

                foreach (var v in u.Nodo.ListaAdyacencia)
                {
                    if (distancias[v.Key] > distancias[u.Nodo] + v.Value.Costo)
                    {
                        distancias[v.Key] = distancias[u.Nodo] + v.Value.Costo;
                        shortest[v.Key] = u.Nodo;
                        //nodes.Add(new BinaryNode(v.Key, distance[v.Key]));
                    }

                }
            }
        }

        public string ToDotFormat()
        {
            string b = Type == GraphType.Undirected ? "graph {" : "digraph {";

            var addedEdges = new List<Edge>();
            b += "{" + string.Join(";", Nodes.Select(e => e.Key + " [fillcolor=" + GetColorName(e.Value.Color) + ",style=filled,label=\""+e.Value.Nombre+"\"]")) + "}";
            foreach (var node in Nodes.Values)
            {
                if (!string.IsNullOrEmpty(b))
                    b += ";";

                foreach (var edge in node.ListaAdyacencia)
                    {
                        if (!string.IsNullOrEmpty(b))
                            b += ";";
                        if (!addedEdges.Contains(edge.Value))
                        {
                            b += node.GetId() + (Type == GraphType.Directed ? " -> " : " -- ") + edge.Key.GetId() +
                                 "[label=\"" + edge.Value.Costo +
                                 "\",Cost=\"" + edge.Value.Costo + "\",color=\"" +
                                 GetColorName(edge.Value.Color) + "\"]";
                            addedEdges.Add(edge.Value);
                        }
                    }

                

            }
            b += "}";
            return b;
        }

    }
    [Serializable]
    public class Node
    {
        
        public string Nombre { get; set; }
        private int Id { get; set; }
        public Dictionary<Node, Edge> ListaAdyacencia { get; set; }
        public Color Color { get; set; }

        public Node(int id, string nombre)
        {
            this.Nombre = nombre;
            this.ListaAdyacencia = new Dictionary<Node, Edge>();
            this.Color = System.Drawing.Color.White;
            this.Id = id;
        }

        public Node Copy()
        {
            var nodo = new Node(this.Id, this.Nombre);
            nodo.Color = this.Color;
            return nodo;
        }

        public int GetId()
        {
            return Id;
        }
    }
    [Serializable]
    public class Edge
    {
        public int Costo { get; set; }
        public Color Color { get; set; }

        public Edge(int costo)
        {
            this.Costo = costo;
            this.Color = System.Drawing.Color.Black;
        }

        public Edge Copy()
        {
            var edge = new Edge(this.Costo);
            edge.Color = this.Color;
            return edge;
        }
    }
}
