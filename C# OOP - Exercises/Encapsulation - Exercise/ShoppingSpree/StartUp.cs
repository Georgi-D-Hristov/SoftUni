using _03.ShoppingSpree;

string[] personsInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
string[] productsInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

List<Person> persons = new();
List<Product> products = new();

try
{
    foreach (string person in personsInput)
    {
        string[] personInfo = person
            .Split("=", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string name = personInfo[0];
        decimal money = decimal.Parse(personInfo[1]);
        Person qustomer = new Person(name, money);
        persons.Add(qustomer);
    }
    foreach (string product in productsInput)
    {
        string[] productInfo = product
            .Split("=", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string name = productInfo[0];
        decimal cost = decimal.Parse(productInfo[1]);

        Product stock = new Product(name, cost);
        products.Add(stock);
    }
}
catch (ArgumentException ae)
{

    Console.WriteLine(ae.Message);
    return;

}

if (products.Count == 0 || persons.Count == 0)
{
    return;
}

string command;

while ((command = Console.ReadLine()) != "END")
{
    string[] commandArgs = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string qustomerName = commandArgs[0];
    string productName = commandArgs[1];

    Person qustomer = persons.FirstOrDefault(p => p.Name == qustomerName);
    Product product = products.FirstOrDefault(p => p.Name == productName);

    if (qustomer != null && product != null)
    {
        qustomer.BueProduct(product);
    }

}

foreach (Person person in persons)
{
    if (person.Bag.Count == 0)
    {
        Console.WriteLine($"{person.Name} - Nothing bought");
    }
    else
    {
        Console.WriteLine(person);
    }
}











//Peter=11;George=4
//using System.Diagnostics.Metrics;

//Bread = 10; Milk = 2;
//Peter Bread
//George Milk
//George Milk
//Peter Milk
//END
