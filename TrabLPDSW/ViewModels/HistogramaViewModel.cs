using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

public class HistogramaViewModel : INotifyPropertyChanged
{
    public SeriesCollection Series { get; set; } = new();
    public ObservableCollection<string> Labels { get; set; } = new();

    public void GerarHistograma(IEnumerable<AlunoNota> notas)
    {
        var faixas = new Dictionary<string, int>
        {
            { "0-4", 0 },
            { "5-9", 0 },
            { "10-13", 0 },
            { "14-17", 0 },
            { "18-20", 0 }
        };

        foreach (var nota in notas)
        {
            if (nota.NotaFinal < 5) faixas["0-4"]++;
            else if (nota.NotaFinal < 10) faixas["5-9"]++;
            else if (nota.NotaFinal < 14) faixas["10-13"]++;
            else if (nota.NotaFinal < 18) faixas["14-17"]++;
            else faixas["18-20"]++;
        }

        Series.Clear();
        Labels.Clear();

        Series.Add(new ColumnSeries
        {
            Title = "Notas",
            Values = new ChartValues<int>(faixas.Values)
        });

        foreach (var faixa in faixas.Keys)
            Labels.Add(faixa);

        OnPropertyChanged(nameof(Series));
        OnPropertyChanged(nameof(Labels));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class AlunoNota
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public double NotaFinal { get; set; }
}