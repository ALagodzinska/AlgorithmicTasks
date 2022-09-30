using MinimumLoss;

Console.WriteLine("Minimum Loss!");

var logic = new MinimumLossLogic();

Console.WriteLine("Please input prices for houses, devided by comma");
var input = logic.GetValidInput();
if(input != null)
{
    var minimumLoss = logic.GetMinimumLoss(input);
    Console.WriteLine($"Minimum loss is {minimumLoss}");
    Console.ReadLine();
}
else
{
    Console.WriteLine("You inputted wrong data too many times! No needed values was found!");
}