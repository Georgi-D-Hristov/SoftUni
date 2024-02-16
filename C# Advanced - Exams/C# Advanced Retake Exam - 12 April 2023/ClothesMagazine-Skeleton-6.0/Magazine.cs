namespace ClothesMagazine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }
        public bool RemoveCloth(string color)
        {
            var clothes = Clothes.Where(c=>c.Color == color).FirstOrDefault();
            if (clothes!=null) 
            { 
                Clothes.Remove(clothes);
                return true;
            }
            return false;
        }
        public Cloth GetSmallestCloth()
        {
            var cloth = Clothes.OrderBy(c=>c.Size).FirstOrDefault();
            return cloth;
        }
        public Cloth GetCloth(string color)
        {
            var cloth = Clothes.Find(c => c.Color == color);
            return cloth;
        }

        public int GetClothCount() 
        {
            return Clothes.Count;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach ( var cloyh in Clothes)
            {
                sb.AppendLine(cloyh.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
