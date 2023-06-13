namespace Panda.Web.Data.Models
{
    public class Receipt
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public decimal Fee { get; init; }

        public DateTime IssuedOn { get; init; }

        public User Recipient { get; init; }

        public string RecipientId { get; init; }

        public Package Package { get; init; }

        public string PacageId { get; init; }
    }
}
