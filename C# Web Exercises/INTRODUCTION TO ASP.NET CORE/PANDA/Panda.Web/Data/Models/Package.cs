namespace Panda.Web.Data.Models
{
    public class Package
    {
        public string Id { get; init; }= Guid.NewGuid().ToString();

        public string Description { get; init; }

        public double Weight { get; init; }

        public string ShoppingAddress { get; init; }

        public string Status { get; init;}

        public DateTime EstimatedDeliveryDate { get; init; }

        public User Recipient { get; init; }

        public string RecipientId { get; init; }
    }
}
