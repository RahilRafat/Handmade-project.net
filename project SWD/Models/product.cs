using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_SWD.Models
{

    public class product
    {
        [Key]

        public int product_ID { get; set; }
    

        [Required(ErrorMessage = "The code of product is required")]
        public string product_code { get; set; }

        [Required(ErrorMessage = "The price of product is required")]
        public int product_price { get; set; }

        [Required(ErrorMessage = "The img of product is required")]
        [Display(Name = "img")]
        [DefaultValue("Fci.jpg")]
        public string img { get; set;}

        [ForeignKey("cat_id")]
        public int categoryID { get; set; }
        
        [ForeignKey("seller_id")]
        public int sellerID { get; set; }


        public virtual ICollection <order_item> order_items { get; set; }
       
        public virtual ICollection<payment> Payments { get; set; }
        //public virtual ICollection<comment> comments { get; set; }


        public virtual category category { get; set; }
        public virtual seller seller { get; set; }



    }
}
