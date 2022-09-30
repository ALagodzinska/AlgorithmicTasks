using MakeAlike;

Console.WriteLine("Make Alike!");

var logic = new MakeAlikeLogic();

Console.WriteLine("Please input initial string: ");
var initialString = logic.GetValidInput();
Console.WriteLine("PLease input desired string: ");
var desiredString = logic.GetValidInput();
Console.WriteLine("Please input operations count: ");
var operationCount = logic.GetValidIntInput();

if(initialString != "" && desiredString != "" && operationCount != 0)
{
    var result = logic.GetDesiredString(initialString, desiredString, operationCount);
    Console.WriteLine($"Is it possible to transform string to desired: {result}");
}
else
{
    Console.WriteLine("You inputted wrong data too many times! No needed values was found!");
}

