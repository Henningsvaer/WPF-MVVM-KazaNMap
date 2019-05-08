using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_mapCourseWork
{
    class User : INotifyPropertyChanged
    {
        private int x;
        private int y;

        public int X
        {
            get => x;
            set
            {
                if (value > 0)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value > 0)
                {
                    y = value;
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
