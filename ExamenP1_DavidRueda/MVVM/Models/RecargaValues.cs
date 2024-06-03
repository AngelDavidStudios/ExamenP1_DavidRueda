using PropertyChanged;

namespace ExamenP1_DavidRueda.MVVM.Models;

[AddINotifyPropertyChangedInterface]
public class RecargaValues
{
    public string Recarga { get; set; }
    
    public bool Option1
    {
        get => Recarga == "3";
        set { if (value) Recarga = "3"; }
    }
    
    public bool Option2
    {
        get => Recarga == "5";
        set { if (value) Recarga = "5"; }
    }

    public bool Option3
    {
        get => Recarga == "10";
        set { if (value) Recarga = "10"; }
    }
}