using RemoveToTwo;

var logic = new Logic();

Console.WriteLine("Remove To Two!");

var userInput = logic.GetValidInput();
var countOfLargestStringWithTwoLetterSequence = logic.LongestPossibleStringCount(userInput);
Console.WriteLine(countOfLargestStringWithTwoLetterSequence);
Console.ReadLine();






