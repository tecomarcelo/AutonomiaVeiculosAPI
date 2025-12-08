using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutonomiaVeiculosAPI.Infra.IoC.Converters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        // Define o formato esperado (dd/MM/yyyy) para leitura e escrita
        private const string DateFormat = "dd/MM/yyyy";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            // Garante que o parser entenda o formato dd/MM/yyyy independentemente da cultura do servidor
            return DateOnly.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            // Escreve a data como string formatada dd/MM/yyyy
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
        }
    }
}
