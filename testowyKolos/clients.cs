using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testowyKolos
{
    class clients
    {        
        [Key]
        public int clientId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
