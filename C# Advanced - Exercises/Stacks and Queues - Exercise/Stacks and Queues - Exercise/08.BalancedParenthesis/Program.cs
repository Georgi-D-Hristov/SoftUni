var input = Console.ReadLine().ToCharArray();

if (input.Length % 2 != 0)
{
    Console.WriteLine("NO");
    return;
}

var charStack = new Stack<char>();

foreach (var ch in input)
{
    if ("{[(".Contains(ch))
    {
        charStack.Push(ch);
    }
    else if (ch == ')' && charStack.Peek() == '(')
    {
        charStack.Pop();
    }
    else if (ch == ']' && charStack.Peek() == '[')
    {
        charStack.Pop();
    }
    else if (ch == '}' && charStack.Peek() == '{')
    {
        charStack.Pop();
    }
}

Console.WriteLine(charStack.Any() ? "NO" : "YES");