using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IMainFormView
    {
        void UpdateGraphDisplay();
        // Наприклад:
        // void AddVertexToDisplay(Vertex vertex);
        // void AddEdgeToDisplay(Edge edge);
        // void RemoveElementFromDisplay(GraphElement element);
    }
}
