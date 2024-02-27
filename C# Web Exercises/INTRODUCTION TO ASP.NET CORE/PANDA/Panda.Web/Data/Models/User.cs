namespace Panda.Web.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        {
            Packages = new List<Package>();
            Receipts = new List<Receipt>();
        }
        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
       
        //TODO Roll
    }
}
