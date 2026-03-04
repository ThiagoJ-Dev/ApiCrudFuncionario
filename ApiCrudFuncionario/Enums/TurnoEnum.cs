using System.Text.Json.Serialization;

namespace ApiCrudFuncionario.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum TurnoEnum
    {
        Manha,
        Tarde,
        Noite

    }
}
