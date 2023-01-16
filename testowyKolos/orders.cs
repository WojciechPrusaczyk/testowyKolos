using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testowyKolos
{
    class orders
    {        
        [Key]
        public int orderId { get; set; }
        public string count { get; set; }
        public int productId { get; set; }
    }
}
