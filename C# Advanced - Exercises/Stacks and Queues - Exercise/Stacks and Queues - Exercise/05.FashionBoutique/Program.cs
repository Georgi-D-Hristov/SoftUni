var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
var boxCapacity = int.Parse(Console.ReadLine());

var stack = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    stack.Push(input[i]);
}

var needBoxes = 0;

while(stack.Count > 0)
{
	var clothesCapacity = 0;
	while (boxCapacity>=clothesCapacity&&stack.Count>0)
	{
		clothesCapacity += stack.Peek();
		if (clothesCapacity > boxCapacity)
		{
			break;
		}
		stack.Pop();
	}
	needBoxes++;
}

Console.WriteLine(needBoxes);