using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    public class AnyBuilding : INotifyPropertyChanged
    {
        private string typeBuilding;
        private string nameBuilding;
        private int xBuilding;
        private int yBuilding;
        private int id;

        public AnyBuilding()
        {

        }

        public AnyBuilding(string tB,string nB,int xB,int yB)
        {
            tB = typeBuilding;
            nB = nameBuilding;
            xB = xBuilding;
            yB = yBuilding;
            id = Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType()) return false;

            AnyBuilding ab = (AnyBuilding)obj;

            return (NameBuilding == ab.NameBuilding) 
                && (TypeBuilding == ab.TypeBuilding)
                && (XBuilding == ab.XBuilding)
                && (YBuilding == ab.YBuilding)
                && (Id == ab.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Id { get; set; }

        public string TypeBuilding {
            get
            {
                return typeBuilding;
            }
            set
            {
                typeBuilding = value;
                OnPropertyChanged(nameof(TypeBuilding));
            }
        }
        public string NameBuilding {
            get
            {
                return nameBuilding;
            }
            set
            {
                nameBuilding = value;
                OnPropertyChanged(nameof(NameBuilding));
            }
        }
        public int XBuilding {
            get
            {
                return xBuilding;
            }
            set
            {
                xBuilding = value;
                OnPropertyChanged(nameof(XBuilding));
            }
        }
        public int YBuilding {
            get
            {
                return yBuilding;
            }
            set
            {
                yBuilding = value;
                OnPropertyChanged(nameof(YBuilding));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
