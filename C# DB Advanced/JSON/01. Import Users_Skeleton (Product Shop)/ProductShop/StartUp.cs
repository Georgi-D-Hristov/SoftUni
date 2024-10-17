using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Models;

namespace ProductShop
{
    using ProductShop.Data;

    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            //01
            //var inputJson = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //02
            //var inputJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, inputJson));

            //03
            //var inputJson = File.ReadAllText("../../../Datasets/categories.json");

            //Console.WriteLine(ImportCategories(context, inputJson));

            //04
            //var inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));

            //05
            //Console.WriteLine(GetProductsInRange(context));

            //06
             Console.WriteLine(GetSoldProducts(context));

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users =
                context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        SoldProduct = u.ProductsSold.Select(p => new
                        {
                            p.Name,
                            p.Price,
                           ByerFirstName =  p.Buyer.FirstName,
                           ByerLastName =  p.Buyer.LastName,
                        })
                    }).ToList();

            return JsonSerializeObject(users);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                }).ToList();

            return JsonSerializeObject(productsInRange);
        }

        private static string JsonSerializeObject(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented

            };


            return JsonConvert.SerializeObject(obj, settings);
        }


        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            categories.RemoveAll(c => c.Name == null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}"; ;
        }
    }
}