using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    public class Graph : INotifyPropertyChanged
    {
        private List<AnyBuilding> _NodeSet; // Список всеx зданий
        private List<GraphNode> _GraphNodes; // Список всех узлов графа  

        public Graph()
        {

        }

        public Graph(List<AnyBuilding> anyBuildings)
        {
            _NodeSet = anyBuildings;
            _GraphNodes = new List<GraphNode>();
        }

        public List<AnyBuilding> NodeSet
        {
            get => _NodeSet;
            set
            {
                _NodeSet = value;
                OnPropertyChanged(nameof(NodeSet));
            }
        }
        public List<GraphNode> GraphNodes
        {
            get => _GraphNodes;
            set
            {
                _GraphNodes = value;
                OnPropertyChanged(nameof(GraphNodes));
            }
        }

        public List<AnyBuilding> Nodes
        {
            get
            {
                return _NodeSet;
            }
        }

        public int Count
        {
            get { return _NodeSet.Count; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
