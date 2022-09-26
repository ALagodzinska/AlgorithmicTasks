using RemoveToTwo;

var logic = new RemoveToTwoLogic();

Console.WriteLine("Remove To Two!");

var userInput = logic.GetValidInput();

if (!(userInput == ""))
{
    var countOfLargestStringWithTwoLetterSequence = logic.LongestPossibleStringCount(userInput);
    Console.WriteLine(countOfLargestStringWithTwoLetterSequence);
    Console.ReadLine();
}
else
{
    Console.WriteLine("You had too many tries!");
    Console.WriteLine("Bye!");
}





