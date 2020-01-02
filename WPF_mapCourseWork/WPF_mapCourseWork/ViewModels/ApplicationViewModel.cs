using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WPF_mapCourseWork
{

    class ApplicationViewModel : INotifyPropertyChanged, IDisposable
    {
        private ApplicationContext db;
        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;
        private RelayCommand userClick;
        private RelayCommand route;
        private Graph mainGraph;
        private User user;

        public ObservableCollection<AnyBuilding> RectItems { get; set; }
        public ObservableCollection<User> UserCol { get; set; }
        public ObservableCollection<int> RouteTo { get; set; }

        private IEnumerable<AnyBuilding> anyBuildings;
       
        public IEnumerable<AnyBuilding> AnyBuildings
        {
            get { return anyBuildings; }
            set
            {
                anyBuildings = value;
                OnPropertyChanged(nameof(AnyBuildings));
            }
        }
       

        public ApplicationViewModel()
        {
            user = new User();
            db = new ApplicationContext();
            db.AnyBuildings.Load();
            AnyBuildings = db.AnyBuildings.Local.ToBindingList();

            List<AnyBuilding> ab = new List<AnyBuilding>();
            foreach (AnyBuilding a in AnyBuildings)
            {
                AnyBuilding curAb = new AnyBuilding()
                {
                    TypeBuilding = a.TypeBuilding,
                    NameBuilding = a.NameBuilding,
                    XBuilding = a.XBuilding,
                    YBuilding = a.YBuilding,
                    Id = a.Id,
                };

                ab.Add(curAb);

            }

            RectItems = new ObservableCollection<AnyBuilding>();
            mainGraph = new Graph(ab);
            UserCol = new ObservableCollection<User>();
            RouteTo = new ObservableCollection<int>();

            MakeGraph();
        }
        
        private void MakeGraph()
        {
            UserCol.Add(user);

            RouteTo.Add(0);
            RouteTo.Add(0);
            RouteTo.Add(0);
            RouteTo.Add(0);
            RouteTo.Add(0); // Расстояние между точками

            // заполняем граф
            if (mainGraph.NodeSet != null)
            {
                foreach (AnyBuilding _ab in mainGraph.NodeSet)
                {
                    try
                    {
                        mainGraph.GraphNodes.Add(new GraphNode(_ab.TypeBuilding, _ab.NameBuilding,
                                      _ab.XBuilding, _ab.YBuilding));

                        RectItems.Add(_ab);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());
                        break;
                    }
                }
            }
        }
        

        public RelayCommand UserClick
        {
            get
            {
                if (userClick == null)
                {
                    userClick = new RelayCommand(CatchMouse, obj => true);
                }
                return userClick;
            }
        }

        public void CatchMouse(object obj)
        {
            if (obj != null)
            {
                RouteTo[0] = 0;
                RouteTo[1] = 0;
                RouteTo[2] = 0;
                RouteTo[3] = 0;
                RouteTo[4] = 0;
                
                Point currentPoint = Mouse.GetPosition(obj as UIElement);
                user.X = (int)currentPoint.X;
                user.Y = (int)currentPoint.Y;
                
            }
        }

        public RelayCommand Route
        {
            get
            {
                return route ??
                  (route = new RelayCommand((selectedItem) =>
                  {
                      
                      if (selectedItem == null) return;
                      AnyBuilding anyBuilding = selectedItem as AnyBuilding;
                      
                      RouteTo[0] = anyBuilding.XBuilding + 15;
                      RouteTo[1] = anyBuilding.YBuilding + 15;
                      RouteTo[2] = user.X + 15;
                      RouteTo[3] = user.Y + 15;
                      
                      double[] d = { RouteTo[0], RouteTo[1], RouteTo[2], RouteTo[3] };
                      //Расстояние между точками
                      RouteTo[4] = (int)Math.Sqrt(( Math.Pow((RouteTo[2] - RouteTo[0]),2) + Math.Pow((RouteTo[3] - RouteTo[1]), 2)));
                  }));
            }
        }

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      BuildingsWindow buildingsWindow = new BuildingsWindow(new AnyBuilding());
                      if (buildingsWindow.ShowDialog() == true)
                      {
                          AnyBuilding anyBuilding = buildingsWindow.AnyBuilding;
                          db.AnyBuildings.Add(anyBuilding);
                          RectItems.Add(anyBuilding);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      AnyBuilding anyBuilding = selectedItem as AnyBuilding;

                      AnyBuilding vm = new AnyBuilding()
                      {
                          Id = anyBuilding.Id,
                          TypeBuilding = anyBuilding.TypeBuilding,
                          NameBuilding = anyBuilding.NameBuilding,
                          XBuilding = anyBuilding.XBuilding,
                          YBuilding = anyBuilding.YBuilding,
                      };
                      BuildingsWindow buildingsWindow = new BuildingsWindow(vm);


                      if (buildingsWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          anyBuilding = db.AnyBuildings.Find(buildingsWindow.AnyBuilding.Id);
                          if (anyBuilding != null)
                          {
                              anyBuilding.TypeBuilding = buildingsWindow.AnyBuilding.TypeBuilding;
                              anyBuilding.NameBuilding = buildingsWindow.AnyBuilding.NameBuilding;
                              anyBuilding.XBuilding = buildingsWindow.AnyBuilding.XBuilding;
                              anyBuilding.YBuilding = buildingsWindow.AnyBuilding.YBuilding;
                              db.Entry(anyBuilding).State = EntityState.Modified;

                              int i = 0;
                              foreach(AnyBuilding _ab in RectItems)
                              {
                                  if(_ab.Id == anyBuilding.Id)
                                  {
                                      RectItems[i] = anyBuilding;
                                      break;
                                  }
                                  i++;
                              }
                             
                              db.SaveChanges();
                              
                          }
                      }

                  }));
            }
        }

        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      AnyBuilding anyBuilding = selectedItem as AnyBuilding;

                      RectItems.Remove(RectItems.Where(i => i.Id == anyBuilding.Id).Single());

                      db.AnyBuildings.Remove(anyBuilding);
                      db.SaveChanges();
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        protected virtual void Dispose(bool disposing)
        {
            
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

