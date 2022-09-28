
using LeaderBoard;

LeaderBoardLogic logic = new LeaderBoardLogic();

Console.WriteLine("Leader Board!");

Console.WriteLine("Please input scores for leader board, use comma to separete numbers;");
var inputOne = logic.GetValidInput();

Console.WriteLine("Please input scores of new players, use comma to separete numbers;");
var inputTwo = logic.GetValidInput();

if(inputOne != null && inputTwo != null)
{
    var newPlayersRanks = logic.GetPlayersRanks(inputOne, inputTwo);
    Console.WriteLine("Ranks for new players in a game: ");
    foreach(var rank in newPlayersRanks)
    {
        Console.Write($"{rank}, ");
    }
    Console.ReadLine();
}

else
{
    Console.WriteLine("You inputted wrong data too many times! No needed values was found!");
}