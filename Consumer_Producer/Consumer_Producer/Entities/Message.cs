using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer_Producer.Entities
{
    public class Message
    {
        private String Content { get; set; }
        private DateTime Timestamp { get; set; }
        private int RequisitionId { get; set; }
        private static Guid MicroserviceId { get; set; }


        public Message(){

            Random rand = new Random();           
            Timestamp = DateTime.Now;
            RequisitionId = rand.Next();
            if(MicroserviceId == Guid.Empty)
            {
                MicroserviceId = Guid.NewGuid();
            }

        }

        public String GetText()
        {          
                return $"[Timestamp:{Timestamp}][RequisitionId:{RequisitionId}]";

          }

        public String GetText2()
        {
            return $"{Content} [Timestamp:{Timestamp}]";
        }

        
    }
}
