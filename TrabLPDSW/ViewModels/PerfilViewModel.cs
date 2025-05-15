using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

public class PerfilViewModel : INotifyPropertyChanged
{
    private string _nome;
    private string _email;
    private BitmapImage _foto;

    public string Nome
    {
        get => _nome;
        set { _nome = value; OnPropertyChanged(); }
    }

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }

    public BitmapImage Foto
    {
        get => _foto;
        set { _foto = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}