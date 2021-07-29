using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Productor.Services
{
    public class Produtor
    {
        public string Host { get; set; }
        public string Topico { get; set;}
        public string GroupID { get; set; }


        public Produtor() { }

        public Produtor(string host,string topico,string groupID)
        {
            Host = host;
            Topico = topico;
            GroupID = groupID;
        }
    }
}
