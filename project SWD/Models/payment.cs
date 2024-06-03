using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_SWD.Models
{

    [PrimaryKey(nameof(product_ID), nameof(customer_ID))]
    public class payment
    {
        [Key]
        //public int payment_ID { get; set; }
        public int product_ID { get; set; }
        public int customer_ID { get; set; }
        //public string payment_type { get; set; }
        public DateTime date { get; set; }


        [ForeignKey("product_ID")]
        public product product { get; set; }

        [ForeignKey("customer_ID")]
        public customer customer { get; set; }

        public virtual ICollection<order_item> order_items { get; set; }
        //public virtual customer customer { get; set; }



    }
}
