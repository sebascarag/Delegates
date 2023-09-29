// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void WriteConsoleDelegate(string msg)
{
    Console.WriteLine(msg);
}

Action<string> writeDelegate = WriteConsoleDelegate; // Action: delegado sin retorno

writeDelegate("string delegate");