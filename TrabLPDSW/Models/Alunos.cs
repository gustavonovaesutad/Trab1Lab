using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Aluno
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public double? Notafinal { get; set; }

    public static string SerializeToJson(Aluno aluno)
    {
        return JsonSerializer.Serialize(aluno, new JsonSerializerOptions { WriteIndented = true });
    }

    public static Aluno DeserializeFromJson(string json)
    {
        return JsonSerializer.Deserialize<Aluno>(json);
    }
}
