using Newtonsoft.Json; 
namespace OpenTrainerProject.Model{ 

    public class Cheat
    {
        [JsonProperty("Method")]
        public string Method { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("NewValue")]
        public string NewValue { get; set; }
        public override string ToString()
        {
            return $"Method: {Method}, Address: {Address}, Type: {Type}, NewValue: {NewValue}";
        }
    }
}