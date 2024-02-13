namespace GroceriesManagement
{
    using System.Text;

    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Capacity == Stall.Count || Stall.Contains(product))
            {
                return;
            }
            Stall.Add(product);
        }
        public bool RemoveProduct(string name)
        {
            var product = Stall.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                Stall.Remove(product);
                return true;
            }
            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            var product = Stall.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                var result =Math.Round( product.Price * quantity,2);
                Turnover+= result;
                return $"{product.Name} - {result:f2}$";
            }
            return "Product not found";
        }
        
        public string GetMostExpensive()
        {
            var product = Stall.OrderByDescending(p=>p.Price).FirstOrDefault();
            return product.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Groceries Price List:");

            foreach (var product in Stall)
            {
                sb.AppendLine($"{product.ToString()}");
            }
            
            return sb.ToString().Trim();
        }
    }
}

