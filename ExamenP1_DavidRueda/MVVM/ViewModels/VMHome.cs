using System.Collections.ObjectModel;
using System.Windows.Input;
using ExamenP1_DavidRueda.MVVM.Models;
using PropertyChanged;

namespace ExamenP1_DavidRueda.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class VMHome
{
    public ObservableCollection<string> Operadoras { get; set; }
    public ICommand Recarga_Click { get; set; }
    public RecargaValues RecargaModel { get; set; }

    public VMHome()
    {
        Operadoras = new ObservableCollection<string>
        {
            "Claro",
            "Movistar",
            "Sprint",
            "AT&T",
            "Verizon",
        };
        RecargaModel = new RecargaValues();
        Recarga_Click = new Command(async () => await AlertConfirmation());
    }

    public async Task AlertConfirmation()
    {
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmación", $"¿Estás seguro de que quieres recargar {RecargaModel.Recarga}?", "Sí", "No");
        if (answer)
        {
            await Application.Current.MainPage.DisplayAlert("Confirmado", "Tu recarga ha sido confirmada.", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Cancelado", "Tu recarga ha sido cancelada.", "OK");
        }
    }
}