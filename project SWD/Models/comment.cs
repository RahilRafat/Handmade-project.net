using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_SWD.Models
{
  
    public class comment
    {
        [Key]
        public int report_ID { get; set; }
        //public int customer_ID4 { get; set; }
        //public int product_ID4 { get; set; }
        //public int order_ID4 { get; set; }
        //public int payment_ID4 { get; set; }
        //public int total_cost { get; set; }
        //public DateTime date { get; set; }
        //public virtual customer customer { get; set; }
        //public virtual payment Payment { get; set; }
        //public virtual order order { get; set; }
        
        public string Email { get; set; }
        public string Name { get; set; }
        public string message { get; set; }        
        public int phone { get; set; }
        public int customer_ID1 { get; set; }

        public virtual customer Customer { get; set; }

    }
}
