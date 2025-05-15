using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class AlunosViewModel : INotifyPropertyChanged
{
	public ObservableCollection<Aluno> Alunos { get; set; } = new();

	private Aluno _novoAluno = new();
	public Aluno NovoAluno
	{
		get => _novoAluno;
		set { _novoAluno = value; OnPropertyChanged(); }
	}

	public ICommand AdicionarCommand => new RelayCommand(AdicionarAluno);
	public ICommand RemoverCommand => new RelayCommand<Aluno>(RemoverAluno);

	public void AdicionarAluno()
	{
		if (!string.IsNullOrWhiteSpace(NovoAluno.Nome) && NovoAluno.Numero > 0)
		{
			Alunos.Add(new Aluno
			{
				Numero = NovoAluno.Numero,
				Nome = NovoAluno.Nome,
				Email = NovoAluno.Email
			});
			NovoAluno = new Aluno(); // reset
		}
	}

	public void RemoverAluno(Aluno aluno)
	{
		Alunos.Remove(aluno);
	}

	public event PropertyChangedEventHandler PropertyChanged;
	private void OnPropertyChanged([CallerMemberName] string nome = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
}