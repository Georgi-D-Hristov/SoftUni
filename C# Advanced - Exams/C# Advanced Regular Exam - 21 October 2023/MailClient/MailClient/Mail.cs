namespace MailClient
{
    using System.Text;

    public class Mail
    {
        public Mail(string sender, string receiver, string body)
        {
            Sender = sender;
            Receiver = receiver;
            Body = body;
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }

        public override string? ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"From: {Sender} / To: {Receiver}");
            sb.AppendLine($"Message: {Body}");

            return sb.ToString().Trim();
        }
    }
}
