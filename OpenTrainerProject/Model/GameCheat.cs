using Newtonsoft.Json; 
namespace OpenTrainerProject.Model{ 

    public class GameCheat
    {
        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("Hotkey")]
        public Hotkey Hotkey { get; set; }

        [JsonProperty("Cheat")]
        public Cheat Cheat { get; set; }
        public override string ToString()
        {
            return $"Label: {Label}, Hotkey: {Hotkey?.ToString()}, Cheat: {Cheat?.ToString()}";
        }
    }
}