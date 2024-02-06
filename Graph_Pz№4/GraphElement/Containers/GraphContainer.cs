using System.Collections.Generic;
using System.Linq;
using GraphElement;

namespace Containers
{
    public class GraphContainer
    {
        private readonly List<Graph> elements = new List<Graph>();

        public void AddElement(Graph element)
        {
            elements.Add(element);
        }

        public bool RemoveElement(Graph element)
        {
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

        // Можна додати додаткові методи для фільтрації, пошуку тощо
    }
}
