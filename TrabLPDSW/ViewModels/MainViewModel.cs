using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TrabLPDSW.Views;

public class MainViewModel : INotifyPropertyChanged
{
    private object _currentView;
    public object CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; OnPropertyChanged(); }
    }

    public ICommand ShowPerfilCommand { get; }
    public ICommand ShowPautaCommand { get; }
    public ICommand ShowHistogramaCommand { get; }

    public MainViewModel()
    {
        ShowPerfilCommand = new RelayCommand(ShowPerfil);
        ShowPautaCommand = new RelayCommand(ShowPauta);
        ShowHistogramaCommand = new RelayCommand(ShowHistograma);

        // Set default view
        CurrentView = new PerfilView();
    }

    private void ShowPerfil() => CurrentView = new PerfilView();
    private void ShowPauta() => CurrentView = new PautaView();
    private void ShowHistograma() => CurrentView = new HistogramaView();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}