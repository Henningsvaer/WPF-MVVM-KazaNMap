using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    public class GraphNode : INotifyPropertyChanged
    {
        private int _id;
        private string _imageType;
        private string _nameBuildingOnGraphNode;
        private int _xCoord;
        private int _yCoord;

        
        public GraphNode(string imageType = "Тип неизвестен", 
                         string nameBuildingOnGraphNode = "Имя неизвестно",
                         int xCoord = 0,int yCoord = 0) 
        {
            _id = Id;
            _imageType = imageType;
            _nameBuildingOnGraphNode = nameBuildingOnGraphNode;
            if(xCoord > 0)
                _xCoord = xCoord;
            if(yCoord > 0)
                _yCoord = yCoord;
        }

        public string ImageType
        {
            get
            {
                return _imageType;
            }
            set
            {
                _imageType = value;
                OnPropertyChanged(nameof(ImageType));
            }
        }
        public string NameBuildingOnGraphNode
        {
            get
            {
                return _nameBuildingOnGraphNode;
            }
        }
        public int XCoord
        {
            get
            {
                return _xCoord;
            }
            set
            {
                if (value > 0)
                    _xCoord = value;
                OnPropertyChanged(nameof(XCoord));
            }
        }
        public int YCoord
        {
            get
            {
                return _yCoord;
            }
            set
            {
                if (value > 0)
                    _yCoord = value;
                OnPropertyChanged(nameof(YCoord));
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
