using System; //For DateTime type
using System.ComponentModel.DataAnnotations; //For attributes like [Key], [Required]
using System.Text.Json;
using System.Text.Json.Serialization; // For Json serialization customization

namespace _3dsGamesAPI.Models //Organize the class in a "Models" namespace
{
    public class Game
    {
        [Key] //Marks GameId as the primary key
        public int GameId { get; set; } // Unique identifier for the game

        [Required] //Ensures that Title is not null or empty
        public string Title { get; set; }

        public string Publisher { get; set; } // Worldwide publisher where applicable

        [JsonConverter(typeof(DateTimeConverter))] // Cuts out time of DateTime using custom class
        public DateTime ReleaseDate { get; set; } // North American release date

        public int CopiesSold { get; set; }

        public bool IsMultiplayer { get; set; }
    }
    //Custom DateTime JSON Conversion
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public const string DateFormat = "yyyy-MM-dd"; //Format for ReleaseDate

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            //check for null
            if (string.IsNullOrEmpty(dateString))
            {
                throw new InvalidOperationException("Date string is null or empty");
            }
            return DateTime.Parse(dateString);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }
}