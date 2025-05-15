using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class TarefasViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public ObservableCollection<Grupo> Grupos { get; set; } = new(); // populado de fora

    private Tarefa _novaTarefa = new();
    public Tarefa NovaTarefa
    {
        get => _novaTarefa;
        set { _novaTarefa = value; OnPropertyChanged(); }
    }

    public ICommand AdicionarTarefaCommand => new RelayCommand(AdicionarTarefa);
    public ICommand RemoverTarefaCommand => new RelayCommand<Tarefa>(RemoverTarefa);
    public ICommand AtribuirNotaCommand => new RelayCommand<AvaliacaoParametro>(AtribuirNota);

    public void AdicionarTarefa()
    {
        if (!string.IsNullOrWhiteSpace(NovaTarefa.Titulo) && NovaTarefa.Peso > 0)
        {
            NovaTarefa.Id = Tarefas.Count + 1;
            NovaTarefa.Avaliacoes = new Dictionary<Grupo, double>();
            foreach (var grupo in Grupos)
                NovaTarefa.Avaliacoes[grupo] = 0; // nota padrão

            Tarefas.Add(NovaTarefa);
            NovaTarefa = new Tarefa();
        }
    }

    public void RemoverTarefa(Tarefa tarefa)
    {
        Tarefas.Remove(tarefa);
    }

    public void AtribuirNota(AvaliacaoParametro param)
    {
        if (param?.Tarefa != null && param.Grupo != null)
        {
            param.Tarefa.Avaliacoes[param.Grupo] = param.Nota;
            OnPropertyChanged(nameof(Tarefas));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string nome = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
}

public class AvaliacaoParametro
{
    public Tarefa Tarefa { get; set; }
    public Grupo Grupo { get; set; }
    public double Nota { get; set; }
}