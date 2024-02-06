using Containers;

namespace Controllers
{
    public class GraphController
    {
        private GraphContainer graphContainer;
        private IMainFormView mainFormView;

        public GraphController(IMainFormView mainFormView)
        {
            this.graphContainer = new GraphContainer();
            this.mainFormView = mainFormView;
            // Немає прямого звернення до MainForm, тільки через інтерфейс
        }

        public void AddVertex(/* параметри для створення вершини */)
        {
            // Логіка додавання вершини
            // Оновлення MainForm за потреби
        }

        public void AddEdge(/* параметри для створення дуги */)
        {
            // Логіка додавання дуги
            // Оновлення MainForm за потреби
        }

        public void RemoveElement(/* параметри для ідентифікації та видалення елемента */)
        {
            // Логіка видалення елемента
            // Оновлення MainForm за потреби
        }

        // Інші методи, що маніпулюють даними і взаємодіють з видом
    }

}
