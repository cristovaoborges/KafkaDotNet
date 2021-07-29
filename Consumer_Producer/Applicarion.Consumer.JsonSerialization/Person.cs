using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicarion.Consumer.JsonSerialization
{
    public class Person
    {

        [JsonRequired]
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonRequired]
        [JsonProperty("sobrenome")]
        public string SobreNome { get; set; }
        
        [Range(0,110)]
        public int Idade { get; set; }


    }
}
