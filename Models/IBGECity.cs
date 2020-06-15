using Newtonsoft.Json;

namespace LocationFunction.Models
{
    public class IBGECity
    {
        private int identifier;
        private string name;

        [JsonProperty("id")]
        public int Identifier { set => identifier = value; get => identifier; }

        [JsonProperty("nome")]
        public string Nome { set => name = value; }

        public string Name { get => name; }
    }
}