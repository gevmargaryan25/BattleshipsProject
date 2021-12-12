using Battleships.Models;
using Battleships.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
    }
}
