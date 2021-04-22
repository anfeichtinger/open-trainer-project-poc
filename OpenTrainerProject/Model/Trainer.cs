using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Text;

namespace OpenTrainerProject.Model{ 

    public class Trainer
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("GameId")]
        public string GameId { get; set; }

        [JsonProperty("GameName")]
        public string GameName { get; set; }

        [JsonProperty("GameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("GameCheats")]
        public GameCheat[] GameCheats { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder($"Id: {Id}, GameId: {GameId}, GameName: {GameName}, GameVersion: {GameVersion}, Cheats: [");
            foreach (GameCheat gameCheat in GameCheats)
            {
                builder.Append(gameCheat.ToString());
            }
            builder.Append("]");
            return builder.ToString();
        }
    }
}