using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    class User : INotifyPropertyChanged
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                if (value > 0)
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                if (value > 0)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                }

            }
        }

        public User()
        {
            X = 0;
            Y = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
