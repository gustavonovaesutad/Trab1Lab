using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Grupo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Aluno> ListaAlunos { get; set; } = new List<Aluno>();

    public static string SerializeToJson(Grupo grupo)
    {
        return JsonSerializer.Serialize(grupo, new JsonSerializerOptions { WriteIndented = true });
    }

    public static Grupo DeserializeFromJson(string json)
    {
        return JsonSerializer.Deserialize<Grupo>(json);
    }
}
