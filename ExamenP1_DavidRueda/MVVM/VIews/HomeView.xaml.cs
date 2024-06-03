using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenP1_DavidRueda.MVVM.ViewModels;

namespace ExamenP1_DavidRueda.MVVM.VIews;

public partial class HomeView : ContentPage
{
    public HomeView()
    {
        InitializeComponent();
        BindingContext = new VMHome();
    }
}