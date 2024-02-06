using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphElement;

namespace Containers
{
    public class GraphContainer
    {
        private List<Graph> elements = new List<Graph>();

        public void RemoveVertexAndConnectedEdges(Vertex vertex)
        {
            var connectedEdges = vertex.Edges.ToList();
            foreach (var edge in connectedEdges)
            {
                RemoveElement(edge);
            }

            RemoveElement(vertex);
        }

        public void AddVertex(Point location, int id)
        {
            // Перед додаванням нової вершини перевіряємо, чи вже існує вершина з таким ID
            if (!elements.OfType<Vertex>().Any(v => v.Id == id))
            {
                var vertex = new Vertex(id, location);
                elements.Add(vertex);
            }
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            // Перед додаванням нової дуги перевіряємо, чи не існує така дуга
            if (!elements.OfType<Edge>().Any(e => e.From == from && e.To == to))
            {
                var edge = new Edge(from, to);
                elements.Add(edge);
                from.Edges.Add(edge); // Зберігаємо дугу у списку дуг початкової вершини
            }
        }

        public bool RemoveElement(Graph element)
        {
            // Для дуг видаляємо їх також зі списків дуг вершин
            if (element is Edge edge)
            {
                edge.From.Edges.Remove(edge);
                edge.To.Edges.Remove(edge);
            }
            // Видаляємо елемент з основного списку
            return elements.Remove(element);
        }

        public IEnumerable<Vertex> GetVertices()
        {
            return elements.OfType<Vertex>();
        }

        public IEnumerable<Edge> GetEdges()
        {
            return elements.OfType<Edge>();
        }

        public List<List<Vertex>> FindCycles()
        {
            var visited = new HashSet<Vertex>();
            var recStack = new Dictionary<Vertex, Vertex>();
            var allCycles = new List<List<Vertex>>();

            foreach (var vertex in GetVertices())
            {
                if (!visited.Contains(vertex))
                {
                    var stack = new Stack<Vertex>();
                    if (FindCyclesUtil(vertex, visited, recStack, stack, allCycles))
                    {
                        // Якщо знайдено цикл, додати його до списку циклів
                        allCycles.Add(new List<Vertex>(stack));
                    }
                }
            }
            return allCycles;
        }

        private bool FindCyclesUtil(Vertex v, HashSet<Vertex> visited, Dictionary<Vertex, Vertex> recStack, Stack<Vertex> stack, List<List<Vertex>> allCycles)
        {
            if (visited.Contains(v))
            {
                if (recStack.ContainsKey(v))
                {
                    // Вершина вже відвідана і в стеку рекурсії, отже цикл знайдено
                    // Зберігаємо вершини з циклу
                    var cycle = new List<Vertex>();
                    Vertex current = v;
                    do
                    {
                        cycle.Add(current);
                        current = recStack[current];
                    } while (current != v);
                    cycle.Reverse();
                    allCycles.Add(cycle);
                    return true;
                }
                return false;
            }

            visited.Add(v);
            recStack[v] = v;
            stack.Push(v);

            foreach (var edge in v.Edges)
            {
                if (FindCyclesUtil(edge.To, visited, recStack, stack, allCycles))
                {
                    return true;
                }
            }

            stack.Pop();
            recStack.Remove(v);

            return false;
        }

        public int VertexCount
        {
            get { return elements.OfType<Vertex>().Count(); }
        }

        public int EdgeCount
        {
            get { return elements.OfType<Edge>().Count(); }
        }

        public Dictionary<Vertex, int> GetVertexDegrees()
        {
            return elements.OfType<Vertex>().ToDictionary(vertex => vertex, vertex => vertex.Edges.Count);
        }

        public IEnumerable<Graph> GetAllElements()
        {
            return elements;
        }

        public GraphInfo GetGraphInfo()
        {
            var cycles = FindCycles();

            return new GraphInfo
            {
                Cycles = cycles,
                VertexCount = GetVertices().Count(),
                EdgeCount = GetEdges().Count(),
                VertexDegrees = GetVertexDegrees(),
            };
        }
    }
}


public class GraphInfo
{
    public List<List<Vertex>> Cycles { get; set; }
    public int VertexCount { get; set; }
    public int EdgeCount { get; set; }
    public Dictionary<Vertex, int> VertexDegrees { get; set; }
    public bool HasCycles => Cycles.Count > 0;

    public GraphInfo()
    {
        Cycles = new List<List<Vertex>>();
        VertexDegrees = new Dictionary<Vertex, int>();
    }
}
