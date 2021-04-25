using Newtonsoft.Json; 
namespace OpenTrainerProject.Model{ 

    public class MemFunction
    {
        [JsonProperty("Method")]
        public string Method { get; set; }

        [JsonProperty("SaveResultFor")]
        public int SaveResultFor { get; set; }

        [JsonProperty("Parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("ResultingAddress")]
        public string ResultingAddress { get; set; }
    }

}