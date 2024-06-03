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
    
    public string NumeroCelular { get; set; }

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
            await SaveToFile(NumeroCelular, RecargaModel.Recarga);

        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Cancelado", "Tu recarga ha sido cancelada.", "OK");
        }
    }


    public async Task SaveToFile(string numeroCelular, string recarga)
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = Path.Combine(docPath, numeroCelular + ".txt");
        string text = $"Se hizo una recarga de {recarga} dólares en la siguiente fecha {DateTime.Now}";
        File.WriteAllText(fileName, text);
    }
}