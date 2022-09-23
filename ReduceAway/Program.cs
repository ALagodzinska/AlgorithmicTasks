using ReduceAway;

var logic = new Logic();

Console.WriteLine("Reduce Away!");
var inputString = logic.GetValidInput();

if(!(inputString == ""))
{
    var finalString = logic.SuperReducedString(inputString);

    Console.WriteLine($"Reduced string: {finalString}");
    Console.ReadLine();
}
else
{
    Console.WriteLine("You had too many tries!");
    Console.WriteLine("Bye!");
}