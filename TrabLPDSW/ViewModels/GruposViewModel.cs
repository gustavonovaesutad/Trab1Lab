using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class GruposViewModel : INotifyPropertyChanged
{
	public ObservableCollection<Grupo> Grupos { get; set; } = new();
	public ObservableCollection<Aluno> AlunosDisponiveis { get; set; } = new();

	private Grupo _novoGrupo = new();
	public Grupo NovoGrupo
	{
		get => _novoGrupo;
		set { _novoGrupo = value; OnPropertyChanged(); }
	}

	private Aluno _alunoSelecionado;
	public Aluno AlunoSelecionado
	{
		get => _alunoSelecionado;
		set { _alunoSelecionado = value; OnPropertyChanged(); }
	}

	public ICommand AdicionarGrupoCommand => new RelayCommand(AdicionarGrupo);
	public ICommand RemoverGrupoCommand => new RelayCommand<Grupo>(RemoverGrupo);
	public ICommand AdicionarAlunoAoGrupoCommand => new RelayCommand(AdicionarAlunoAoGrupo);

	public void AdicionarGrupo()
	{
		if (!string.IsNullOrWhiteSpace(NovoGrupo.Nome))
		{
			Grupos.Add(new Grupo
			{
				Id = NovoGrupo.Id,
				Nome = NovoGrupo.Nome,
				Alunos = new List<Aluno>(NovoGrupo.Alunos)
			});
			NovoGrupo = new Grupo();
		}
	}

	public void RemoverGrupo(Grupo grupo)
	{
		Grupos.Remove(grupo);
	}

	public void AdicionarAlunoAoGrupo()
	{
		if (AlunoSelecionado != null && !NovoGrupo.Alunos.Contains(AlunoSelecionado))
		{
			NovoGrupo.Alunos.Add(AlunoSelecionado);
			AlunosDisponiveis.Remove(AlunoSelecionado);
			AlunoSelecionado = null;
			OnPropertyChanged(nameof(NovoGrupo));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
	private void OnPropertyChanged([CallerMemberName] string nome = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
}