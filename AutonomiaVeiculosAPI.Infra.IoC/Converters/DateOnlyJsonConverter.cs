using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutonomiaVeiculosAPI.Infra.IoC.Converters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        // Define o formato esperado (yyyy-MM-dd) para leitura e escrita
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            // Garante que o parser entenda o formato yyyy-MM-dd independentemente da cultura do servidor
            return DateOnly.ParseExact(value!, DateFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            // Escreve a data como string formatada yyyy-MM-dd
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
        }
    }
}
