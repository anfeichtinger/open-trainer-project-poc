using Newtonsoft.Json; 
namespace OpenTrainerProject.Model{ 

    public class Hotkey
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

}