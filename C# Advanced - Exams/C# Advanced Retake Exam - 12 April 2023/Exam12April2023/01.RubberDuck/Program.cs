var taskTimeInfo = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
var tasksInfo = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var times = new Queue<int>(taskTimeInfo);
var tasks = new Stack<int>(tasksInfo);

var vaderDuck = 0;
var thorDuck = 0;
var bigBlueDuck = 0;
var smalYelowDuck = 0;


while (times.Count>0&&tasks.Count>0)
{
    var time = times.Dequeue();
    var task = tasks.Pop();
    var taskTime = time*task;
    if (taskTime >= 0 && taskTime <= 60)
    {
        vaderDuck++;
    }
   else if (taskTime >= 61 && taskTime <= 120)
    {
        thorDuck++;
    }
  else  if(taskTime >= 121 && taskTime <= 180)
    {
        bigBlueDuck++;
    }
   else if ((taskTime >= 181 && taskTime <= 240))
    {
        smalYelowDuck++;
    }
    else
    {
        tasks.Push(task - 2);
        times.Enqueue(time);
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

Console.WriteLine($"Darth Vader Ducky: {vaderDuck}");
Console.WriteLine($"Thor Ducky: {thorDuck}");
Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueDuck}");
Console.WriteLine($"Small Yellow Rubber Ducky: {smalYelowDuck}");
