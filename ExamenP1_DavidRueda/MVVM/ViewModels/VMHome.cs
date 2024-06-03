using System.Collections.ObjectModel;
using System.Windows.Input;
using ExamenP1_DavidRueda.MVVM.Models;

namespace ExamenP1_DavidRueda.MVVM.ViewModels;

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
            "Entel",
            "Bitel"
        };
        RecargaModel = new RecargaValues();
        Recarga_Click = new Command(async () => await AlertConfirmation());
    }

    public async Task AlertConfirmation()
    {
        bool answer = await Shell.Current.DisplayAlert("Confirmación", $"¿Estás seguro de que quieres recargar {RecargaModel.Recarga}?", "Sí", "No");
        if (answer)
        {
            await Shell.Current.DisplayAlert("Confirmado", "Tu recarga ha sido confirmada.", "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("Cancelado", "Tu recarga ha sido cancelada.", "OK");
        }
    }
}