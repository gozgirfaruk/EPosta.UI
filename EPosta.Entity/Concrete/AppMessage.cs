using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.Entity.Concrete
{
    public class AppMessage
    {
        public int AppMessageID { get; set; }
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string ReceiverMail { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }


    }
}
