using Newtonsoft.Json;

namespace LocationFunction.Models
{
    public class IBGEState
    {
        private int identifier;
        private string initials;
        private string name;

        [JsonProperty("id")]
        public int Identifier { set => identifier = value; get => identifier; }

        [JsonProperty("sigla")]
        public string Sigla { set => initials = value; }

        [JsonProperty("nome")]
        public string Nome { set => name = value; }

        public string Initials { get => initials; }
        public string Name { get => name; }
    }
}