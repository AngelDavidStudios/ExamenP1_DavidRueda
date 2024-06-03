using ExamenP1_DavidRueda.MVVM.VIews;
namespace ExamenP1_DavidRueda;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new HomeView();
    }
}