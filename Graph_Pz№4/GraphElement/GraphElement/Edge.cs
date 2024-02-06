namespace GraphElement
{
    public class Edge : Graph
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public double Weight { get; set; } // Вага дуги, якщо граф ваговий

        public Edge(Vertex from, Vertex to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override void Draw()
        {
            // Код для візуалізації дуги
        }
    }

}
