using Newtonsoft.Json; 
using System.Collections.Generic; 
namespace OpenTrainerProject.Model{ 

    public class GameCheat
    {
        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Hotkey")]
        public Hotkey Hotkey { get; set; }

        [JsonProperty("MemFunctions")]
        public MemFunction[] MemFunctions { get; set; }
    }

}