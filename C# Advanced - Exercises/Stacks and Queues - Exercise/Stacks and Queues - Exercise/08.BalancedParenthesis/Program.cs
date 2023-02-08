var inputLine = Console.ReadLine().ToArray();

var closed = new Queue<char>();
var openned = new Stack<char>();

for (int i = 0; i < (inputLine.Length); i++)
{
    closed.Enqueue(inputLine[i]);
}

for (int j = 0; j < (inputLine.Length) / 2; j++)
{
    openned.Push(closed.Peek());
    closed.Dequeue();
}

var isBalansed = 0;

while (openned.Count > 0 && closed.Count > 0)
{
    var open = openned.Peek();
    var close = closed.Peek();
    if (open == '(' && ')' == close || open == '{' && '}' == close || open == '[' && ']' == close ||
        open == ')' && '(' == close || open == '}' && '{' == close || open == ']' && '[' == close)
    {
        isBalansed++;
    }
    openned.Pop();
    closed.Dequeue();
}
if (isBalansed == inputLine.Count() / 2)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}

