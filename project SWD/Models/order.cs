using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_SWD.Models
{
    
    public class order
    {
        [Key]
        public int order_ID { get; set; }

        public int customerID { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }


        public virtual customer? customer { get; set; }

        public virtual ICollection <order_item>? order_items { get; set; }


        //public virtual customer Customer { get; set; }

    }
}
