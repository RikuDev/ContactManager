using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerContactManager.Models
{
    //[Table("Customer Contact Info")]
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            Customers = new List<ContactInfo>();
        }
        //[Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<ContactInfo> Customers { get; set; }
    }

    public class ContactInfo
    {
        public ContactInfo () { }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        //[ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }
    }
}