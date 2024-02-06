using System.Collections.Generic;


namespace GraphElement
{
    public class Vertex : Graph
    {
        public int Id { get; set; }
        public List<Edge> Edges { get; private set; } // Список дуг, що виходять з вершини

        public Vertex(int id)
        {
            Id = id;
            Edges = new List<Edge>();
        }

        public override void Draw()
        {
            // Код для візуалізації вершини
        }
    }

}
