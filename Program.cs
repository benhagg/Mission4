internal class Program
{
    private static void Main(string[] args)
    {
        // welcome user to the game
        Console.WriteLine("Welcome to the game");

        // init 2d array with empty strings (3x3)
        string[,] gameBoard = new string[3, 3]
        {
            { "", "", "" },
            { "", "", "" },
            { "", "", "" }
        };
        // init player turn (state that stores whose turn it is)
        bool player1Turn = true;
        int row;
        int col;

        while (true)
        {
            // ask player for choice row then column
            Console.WriteLine($"Player {(player1Turn ? "1" : "2")}, enter your choice row (1-3): ");
            while (true)
            {
                try
                {
                    row = int.Parse(Console.ReadLine());
                    if (row >= 1 && row <= 3)
                    {
                        break;
                    }
                }
                catch
                {
                }
                Console.WriteLine("Invalid input. Please enter a row number 1 - 3.");
            }// ask for choice column
            Console.WriteLine($"Player {(player1Turn ? "1" : "2")}, enter your choice column (1-3): ");
            while (true)
            {
                try
                {
                    col = int.Parse(Console.ReadLine());
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
            // update the game board
            gameBoard[row - 1, col - 1] = player1Turn ? "X" : "O";
            // pass the updated board to the GameBoard class
            GameBoard CurrentBoard = new GameBoard(gameBoard);
            // check for win (call method)
            if (CurrentBoard.CheckWin()) // CheckWin returns a boolean
            {
                Console.WriteLine($"Player {(player1Turn ? "1" : "2")} wins!");
                return; // end the game
            }

            Console.WriteLine("Current Game Board");
            CurrentBoard.PrintBoard();
        }
        
    }
}