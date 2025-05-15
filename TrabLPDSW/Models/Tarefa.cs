using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraTermino { get; set; }
    public double Peso { get; set; }
    public Dictionary<Grupo, double> Avaliacoes { get; set; } = new();

    public static string SerializeToJson(Tarefa tarefa)
    {
        return JsonSerializer.Serialize(tarefa, new JsonSerializerOptions { WriteIndented = true });
    }

    public static Tarefa DeserializeFromJson(string json)
    {
        return JsonSerializer.Deserialize<Tarefa>(json);
    }
}
