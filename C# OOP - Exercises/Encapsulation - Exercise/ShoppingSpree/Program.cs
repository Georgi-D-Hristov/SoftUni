using ShoppingSpree;

try
{
    var input = Console.ReadLine();
    var persons = new List<Person>();
    var products = new List<Product>();

    var personsArgs = input.Split(";").ToArray();

    foreach (var personArgs in personsArgs)
    {
        var personInfo = personArgs.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
        var name = personInfo[0];
        var money = decimal.Parse(personInfo[1]);

        var person = new Person(name, money);
        persons.Add(person);
    }

    input = Console.ReadLine();

    var productsArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

    foreach (var item in productsArgs)
    {
        var productArgs = item.Split("=").ToArray();
        var name = productArgs[0];
        var cost = decimal.Parse(productArgs[1]);

        var product = new Product(name, cost);
        products.Add(product);
    }

    input = Console.ReadLine();

    while (input != "END")
    {
        var commands = input.Split().ToArray();
        var personName = commands[0];
        var productName = commands[1];

        var person = persons.FirstOrDefault(p => p.Name == personName);
        var product = products.FirstOrDefault(p => p.Name == productName);

        if (person.Money >= product.Cost)
        {
            person.reduseMoney(product);
            person.AddProduct(product);

            Console.WriteLine($"{person.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{person.Name} can't afford {product.Name}");
        }

        input = Console.ReadLine();
    }

    foreach(var person in persons)
    {
        if (person.IsBagEmpty())
        {
            Console.WriteLine($"{person.Name} - Nothing bought");
        }
        else
        {
            Console.WriteLine($"{person.Name} - {person.ShowBagProducts()}");
        }
       
    }
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}


