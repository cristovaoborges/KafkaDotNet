using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Productor.Services
{
    public class ServiceProdutor
    {
        public static List<Produtor> GetProdutors()
        {
            var listaProdutores = new List<Produtor>()
            { 
                new Produtor{Topico = "EMAIL",GroupID = "EMAIL_GROUP"},
                new Produtor{Topico = "FRAUDE",GroupID = "FRAUDE_GROUP"}

            };
            return listaProdutores;
        }
    }
}
