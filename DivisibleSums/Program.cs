using DivisibleSums;
using System.Collections;

var logic = new DivisibleSumsLogic();
Console.WriteLine("Devisible Sums!");
Console.WriteLine("Please input number for the divisor: ");
var divisor = logic.GetValidIntInput();

Console.WriteLine("Please input set of numbers, use comma to separete numbers;");
var intArray = logic.GetValidArrayInput();

if(divisor != null && intArray != null)
{
    Console.WriteLine("Length of longest subset");
    logic.Run(divisor.Value, intArray);
    
    Console.ReadLine();
}
else
{
    Console.WriteLine("You inputted wrong data too many times! No needed values was found!");
}
