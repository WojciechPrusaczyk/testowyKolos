using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testowyKolos
{
    class products
    {        
        [Key]
        public int productId { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }
}
