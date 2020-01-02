using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    public class AnyBuilding : INotifyPropertyChanged
    {
        private string _typeBuilding;
        private string _nameBuilding;
        private int _xBuilding;
        private int _yBuilding;
        private int _id;

        public AnyBuilding()
        {

        }

        public AnyBuilding(string typeBuilding, string nameBuilding, 
                           int xBuilding, int yBuilding, int id)
        {
            this._typeBuilding = typeBuilding;
            this._nameBuilding = nameBuilding;
            this._xBuilding = xBuilding;
            this._yBuilding = yBuilding;
            this.Id = id;
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

        public int Id {
            get
            {
                return _id;
            }
            set  
            { 
                if(value > 0 && value.GetType() == typeof(int))
                {
                    _id = value;
                }
            }
        }

        public string TypeBuilding {
            get
            {
                return _typeBuilding;
            }
            set
            {
                _typeBuilding = value;
                OnPropertyChanged(nameof(TypeBuilding));
            }
        }
        public string NameBuilding {
            get
            {
                return _nameBuilding;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    _nameBuilding = value;
                }
                OnPropertyChanged(nameof(NameBuilding));
            }
        }
        public int XBuilding {
            get
            {
                return _xBuilding;
            }
            set
            {
                if (value > 0 && value.GetType() == typeof(int))
                {
                    _xBuilding = value;
                }
                OnPropertyChanged(nameof(XBuilding));
            }
        }
        public int YBuilding {
            get
            {
                return _yBuilding;
            }
            set
            {
                if (value > 0 && value.GetType() == typeof(int))
                {
                    _yBuilding = value;
                }
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
