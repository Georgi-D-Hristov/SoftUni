using BoxData;

var inputLength = double.Parse(Console.ReadLine());
var inputWidth = double.Parse(Console.ReadLine());
var inputHeight = double.Parse(Console.ReadLine());

try
{
    var box = new Box(inputLength, inputWidth, inputHeight);
    Console.WriteLine(box);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}