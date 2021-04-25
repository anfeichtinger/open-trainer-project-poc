using Newtonsoft.Json; 
namespace OpenTrainerProject.Model{ 

    public class Parameters
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("writable")]
        public bool? Writable { get; set; }

        [JsonProperty("executable")]
        public bool? Executable { get; set; }
    }

}