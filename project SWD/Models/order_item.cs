using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_SWD.Models
{
   
    public class order_item
    {
        [Key]
        [Required]
        public int orderItem_ID { get; set; }
         public int product_price { get; set; }
        //public int order_ID1 { get; set; }
        //public int customer_ID1 { get; set; }
        public int product_ID1 { get; set; }
        public int quantity { get; set; }
      
        public DateTime date { get; set; }
       



        //public virtual ICollection<payment> Payments { get; set; }
        public virtual product product { get; set; }
        public virtual order order { get; set; }


    }
}
