// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello from Kluska's HelperTool!");

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"Argument={arg}");
    }
}
else
{
    Console.WriteLine("No arguments");
}
