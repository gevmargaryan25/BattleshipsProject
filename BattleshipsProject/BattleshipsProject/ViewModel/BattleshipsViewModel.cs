using Battleships.Models;
using BattleshipsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Battleships.ViewModels
{
    public class BattleshipsViewModel : INotifyPropertyChanged
    {

        public BattleshipsViewModel()
        {
            BoardGenerator = new BoardGenerator();
            Comp = BoardGenerator.Generate(10);
            User = BoardGenerator.Generate(10);
            list = new List<Pair>();
            localBoard = new int[10, 10];
        }

        private void NewGame()
        {
            Comp = BoardGenerator.Generate(10);
            User = BoardGenerator.Generate(10);
            BoardVisibility = false;
            ButtonsVisibility = true;
        }

        public void GenerateUserBoard()
        {
            User = BoardGenerator.Generate(10);
        }

        public BoardGenerator BoardGenerator { get; set; }
        
        

        public List<List<Position>> Comp { get; set; }


        private List<List<Position>> _user;
        public List<List<Position>> User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        private bool _boardVisibility = false;

        public bool BoardVisibility
        {
            get { return _boardVisibility; }
            set 
            { 
                _boardVisibility = value;
                OnPropertyChanged("BoardVisibility");
            }
        }
        
        private bool _buttonsVisibility = true;

        public bool ButtonsVisibility
        {
            get { return _buttonsVisibility; }
            set 
            {
                _buttonsVisibility = value;
                OnPropertyChanged("ButtonsVisibility");
            }
        }


        private string s = "";
        public string S
        {
            get { return s; }
            set
            {
                s = value;
                OnPropertyChanged("S");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public static List<Pair> list;
        public static int flag = 0;
        public static int left;
        public static int right;
        public static int bottom;
        public static int up;
        public static int x;
        public static int y;
        public static int[,] localBoard;
        public static int result;

        private void Occupy(int[,] localBoard, List<Pair> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].x != 0 && list[i].y != 0 && list[i].x != 9 && list[i].y != 9)
                {
                    localBoard[list[i].x - 1, list[i].y - 1] = 1;
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y + 1] = 1;

                    localBoard[list[i].x , list[i].y - 1] = 1;
                    localBoard[list[i].x , list[i].y + 1] = 1;

                    localBoard[list[i].x + 1, list[i].y - 1] = 1;
                    localBoard[list[i].x + 1, list[i].y] = 1;
                    localBoard[list[i].x + 1, list[i].y + 1] = 1;

                }

                else if (list[i].x == 0 && list[i].y != 0 && list[i].y != 9)
                {
                    localBoard[list[i].x , list[i].y - 1] = 1;
                    localBoard[list[i].x , list[i].y + 1] = 1;

                    localBoard[list[i].x + 1, list[i].y - 1] = 1;
                    localBoard[list[i].x + 1, list[i].y] = 1;
                    localBoard[list[i].x + 1, list[i].y + 1] = 1;
                }

                else if (list[i].x != 0 && list[i].y == 0 && list[i].x != 9)
                {
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y + 1] = 1;

                    localBoard[list[i].x, list[i].y + 1] = 1;

                    localBoard[list[i].x + 1, list[i].y] = 1;
                    localBoard[list[i].x + 1, list[i].y + 1] = 1;
                }
                else if (list[i].x == 9 && list[i].y != 0 && list[i].y != 9)
                {
                    localBoard[list[i].x - 1, list[i].y - 1] = 1;
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y + 1] = 1;

                    localBoard[list[i].x , list[i].y - 1] = 1;
                    localBoard[list[i].x , list[i].y + 1] = 1;
                }

                else if (list[i].y == 9 && list[i].x != 0 && list[i].x != 9)
                {
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y - 1] = 1;

                    localBoard[list[i].x , list[i].y - 1] = 1;

                    localBoard[list[i].x + 1, list[i].y] = 1;
                    localBoard[list[i].x + 1, list[i].y - 1] = 1;
                }

                else if (list[i].x == 0 && list[i].y == 0)
                {
                    localBoard[list[i].x, list[i].y + 1] = 1;
                    localBoard[list[i].x + 1, list[i].y] = 1;
                    localBoard[list[i].x + 1, list[i].y + 1] = 1;
                }

                else if (list[i].x == 9 && list[i].y == 0)
                {
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y + 1] = 1;
                    localBoard[list[i].x , list[i].y + 1] = 1;
                }

                else if (list[i].x == 0 && list[i].y == 9)
                {
                    localBoard[list[i].x, list[i].y - 1] = 1;
                    localBoard[list[i].x + 1, list[i].y - 1] = 1;
                    localBoard[list[i].x + 1, list[i].y] = 1;
                }

                else if (list[i].x == 9 && list[i].y == 9)
                {
                    localBoard[list[i].x - 1, list[i].y] = 1;
                    localBoard[list[i].x - 1, list[i].y - 1] = 1;

                    localBoard[list[i].x , list[i].y - 1] = 1;
                }
            }
        }

        private async void HitWithDirection(int x, int y)
        {
            int temp_x = x;
            int temp_y = y;
            while (temp_x != 0 && left == 0)
            {
                --temp_x;

                result = BoardGenerator.Hit(User, temp_x, temp_y);
                if (result == 0)
                {
                    left = 1;
                    flag = 1;
                    localBoard[temp_x, temp_y] = 1;
                    User[temp_x][temp_y].Text = ".";
                    return;
                }
                else if (result == 1)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    User[temp_x][temp_y].Text = "X";
                    continue;
                }
                else if (result == 2)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    Occupy(localBoard, list);
                    flag = 0;
                    User[temp_x][temp_y].Text = "X";
                    Shoot();
                    return;
                }
                else
                {
                    // game over
                    var dialog = new ContentDialog
                    {
                        Title = "You lost:(",
                        CloseButtonText = "close"
                    };
                    await dialog.ShowAsync();
                    NewGame();
                }
            }

            while (x != 9 && right == 0)
            {
                ++temp_x;
                result = BoardGenerator.Hit(User, temp_x, temp_y);
                if (result == 0)
                {
                    right = 1;
                    flag = 1;
                    localBoard[temp_x, temp_y] = 1;
                    User[temp_x][temp_y].Text = ".";
                    return;
                }
                else if (result == 1)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    User[temp_x][temp_y].Text = "X";
                    continue;
                }
                else if (result == 2)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    Occupy(localBoard, list);
                    flag = 0;
                    User[temp_x][temp_y].Text = "X";
                    Shoot();
                    return;
                }
                else
                {
                    // game over
                    var dialog = new ContentDialog
                    {
                        Title = "You lost:(",
                        CloseButtonText = "close"
                    };
                    await dialog.ShowAsync();
                    NewGame();
                }
            }

            while (y != 9 && bottom == 0)
            {
                ++temp_y;
                result = BoardGenerator.Hit(User, temp_x, temp_y);
                if (result == 0)
                {
                    bottom = 1;
                    flag = 1;
                    localBoard[temp_x, temp_y] = 1;
                    User[temp_x][temp_y].Text = ".";
                    return;
                }
                else if (result == 1)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    User[temp_x][temp_y].Text = "X";
                    continue;
                }
                else if (result == 2)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    Occupy(localBoard, list);
                    flag = 0;
                    User[temp_x][temp_y].Text = "X";
                    Shoot();
                    return;
                }
                else
                {
                    // game over
                    var dialog = new ContentDialog
                    {
                        Title = "You lost:(",
                        CloseButtonText = "close"
                    };
                    await dialog.ShowAsync();
                    NewGame();
                }
            }

            while (y != 0 && up == 0)
            {
                --temp_y;
                result = BoardGenerator.Hit(User, temp_x, temp_y);
                if (result == 0)
                {
                    up = 1;
                    flag = 1;
                    localBoard[temp_x, temp_y] = 1;
                    User[temp_x][temp_y].Text = ".";
                    return;
                }
                else if (result == 1)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    User[temp_x][temp_y].Text = "X";
                    continue;
                }
                else if (result == 2)
                {
                    localBoard[temp_x, temp_y] = 1;
                    list.Add(new Pair { x = temp_x, y = temp_y });
                    Occupy(localBoard, list);
                    flag = 0;
                    User[temp_x][temp_y].Text = "X";
                    Shoot();
                    return;
                }
                else
                {
                    // game over
                    var dialog = new ContentDialog
                    {
                        Title = "You lost:(",
                        CloseButtonText = "close"
                    };
                    await dialog.ShowAsync();
                    NewGame();
                }
            }

        }

        public async void Shoot()
        {
            if (flag == 0)
            {
                flag = 1;
                left = 0;
                right = 0;
                up = 0;
                bottom = 0;
                Random rand = new Random();
                while (true)
                {
                    x = rand.Next(0, 10);
                    y = rand.Next(0, 10);
                    if (localBoard[x, y] == 0)
                    {
                        localBoard[x, y] = 1;
                        break;
                    }
                }
            }
            result = BoardGenerator.Hit(User, x, y);
            switch (result)
            {
                case 0:
                    flag = 0;
                    User[x][y].Text = ".";
                    break;
                case 1:
                    User[x][y].Text = "X";
                    HitWithDirection(x, y);
                    break;
                case 2:
                    flag = 0;
                    User[x][y].Text = "X";
                    Shoot();
                    break;
                case 3:
                    // game over
                    var dialog = new ContentDialog
                    {
                        Title = "You lost:(",
                        CloseButtonText = "close"
                    };
                    await dialog.ShowAsync();
                    NewGame();
                    break;
                default:
                    break;

            }

        }
    }



}
