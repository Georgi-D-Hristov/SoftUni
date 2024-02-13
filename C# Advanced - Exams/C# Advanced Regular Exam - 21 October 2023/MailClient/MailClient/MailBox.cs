namespace MailClient
{
    using System.Text;

    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count==Capacity)
            {
                return;
            }
            Inbox.Add(mail);
        }
        public bool DeleteMail(string sender)
        {
            if (Inbox.Any(m=>m.Sender == sender))
            {
                Inbox.Remove(Inbox.First(s=>s.Sender == sender));
                return true;
            }
            return false;
        }
        public int ArchiveInboxMessages()
        {
            var mailCount = Inbox.Count;

            foreach (var mail in Inbox)
            {
                Archive.Add(mail);
            }
            Inbox.RemoveRange(0, mailCount);

            return mailCount;
        }
        public string GetLongestMessage()
        {
            return Inbox.OrderByDescending(m => m.Body.Length).First().ToString();
        }
        public string InboxView()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach(var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
