using Newtonsoft.Json; 
using System.Collections.Generic; 
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

        [JsonProperty("Is64Bit")]
        public bool Is64Bit { get; set; }

        [JsonProperty("GameCheats")]
        public GameCheat[] GameCheats { get; set; }
    }

}