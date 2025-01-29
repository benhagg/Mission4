using Mission4;
internal class Program
{
    private static void Main(string[] args)
    {
        // welcome user to the game
        Console.WriteLine("Welcome to the game");
        processBoard pb = new processBoard();
        // init 2d array with empty strings (3x3)
        string[,] gameBoard = new string[3, 3]
        {
            { "", "", "" },
            { "", "", "" },
            { "", "", "" }
        };
        pb.printBoard(gameBoard);
        // init player turn
        bool player1Turn = true;
        // ask player for choice row then column
        Console.WriteLine($"Player {(player1Turn ? "1":"2")}, enter your choice row: ");
        while (true) {
            try
            {
                int row = int.Parse(Console.ReadLine());
                if (row >= 1 && row <= 3)
                {
                    break;
                }
            }
            catch
            {
            }
            Console.WriteLine("Invalid input. Please enter a row number 1 - 3.");
        }
        Console.WriteLine($"Player {(player1Turn ? "1" : "2")}, enter your choice column: ");
        while (true)
        {
            try
            {
                int col = int.Parse(Console.ReadLine());
                if (col >= 1 && col <= 3)
                {
                    break;
                }
            }
            catch
            {
            }
            Console.WriteLine("Invalid input. Please enter a column number 1 - 3.");
        }

        // print the board (call method)

        // check for win (call method)
    }
}