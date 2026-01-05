
class Program

       Console.WriteLine("Hej. Welcome to the spare parts inventory! ");
bool partAvailable = false;
while (!partAvailable)
{
    Console.Write("Which part do you need? ");
    var line = Console.ReadLine();
    if (line == "hydraulic pump" || line == "PLC module" || line == "servo motor")
    {
        Console.WriteLine($"I have got {line} here for you 😊. Bye!");
        partAvailable = true;
    }
    else  if (line == "Do you actually have any parts?" || line == "Is there anything in stock at all?")
    {
        Console.WriteLine("""
                          We have 3 part(s)!
                          hydraulic pump
                          PLC module
                          servo motor
                          """);
    }
    else
        Console.WriteLine($"I am afraid we don’t have any {line} in the inventory");
}
                          
