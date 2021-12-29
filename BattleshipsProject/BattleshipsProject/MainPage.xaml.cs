using Battleships.Models;
using Battleships.ViewModels;
using System;
using System.Drawing;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
namespace Battleships
{
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new BattleshipsViewModel();
        }

        public BattleshipsViewModel ViewModel
        {
            get { return (BattleshipsViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
           DependencyProperty.Register("ViewModel", typeof(Position), typeof(MainPage), new PropertyMetadata(null));

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Position position)
            {
                switch (position.ShipType)
                {
                    case 0:
                        position.PlaceHolderText = ".";
                        ViewModel.Shoot();
                        break;
                    case 1:
                        position.PlaceHolderText = "1";
                        int result = BoardGenerator.Hit(ViewModel.Comp, position.Row, position.Column);
                        if (result == 3)
                        {
                            var dialog = new ContentDialog
                            {
                                Title = "You win!!!",
                                CloseButtonText = "close"
                            };
                            await dialog.ShowAsync();
                            ViewModel = new BattleshipsViewModel();
                        }
                        break;
                    case 2:
                        position.PlaceHolderText = "2";
                        result = BoardGenerator.Hit(ViewModel.Comp, position.Row, position.Column);
                        if (result == 3)
                        {
                            var dialog = new ContentDialog
                            {
                                Title = "You win!!!",
                                CloseButtonText = "close"
                            };
                            await dialog.ShowAsync();
                            ViewModel = new BattleshipsViewModel();
                        }
                        break;
                    case 3:
                        position.PlaceHolderText = "3";
                        result = BoardGenerator.Hit(ViewModel.Comp, position.Row, position.Column);
                        if (result == 3)
                        {
                            var dialog = new ContentDialog
                            {
                                Title = "You win!!!",
                                CloseButtonText = "close"
                            };
                            await dialog.ShowAsync();
                            ViewModel = new BattleshipsViewModel();
                        }
                        break;
                    case 4:
                        position.PlaceHolderText = "4";
                        result = BoardGenerator.Hit(ViewModel.Comp, position.Row, position.Column);
                        if (result == 3)
                        {
                            var dialog = new ContentDialog
                            {
                                Title = "You win!!!",
                                CloseButtonText = "close"
                            };
                            await dialog.ShowAsync();
                            ViewModel = new BattleshipsViewModel();
                        }
                        break;
                    default:
                        break;
                }
                    
            }

        }

        private async void ChangeBoard_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.GenerateUserBoard();
        }

        private void ReadyToStart_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.BoardVisibility = true;
            ViewModel.ButtonsVisibility = false;
        }
    }
}
