using QueensAttack;

Console.WriteLine("Queens Attack!");

var logic = new QueensAttackLogic();

var squaresToAttack = logic.SquaresToAttack();
Console.WriteLine($"Scuare count to attack: {squaresToAttack}");