using TicTacToe_lib;

Game game = new Game();
while (game.IsGameRunning)
{
    Console.WriteLine(game.PrintTable());
    Console.WriteLine($"Current player: {game.CurrentPlayer}");
    Console.WriteLine("Enter your move (row column): ");
    string input = Console.ReadLine()!;
    game.PutTable(input);
    game.CheckDraw();
    game.CheckWin();
}
Console.Clear();
Console.WriteLine(game.PrintTable());
Console.WriteLine(game.Msg);
