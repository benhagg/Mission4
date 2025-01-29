using Mission4;
internal class Program
{
    private static void Main(string[] args)
    {
        // welcome user to the game
        Console.WriteLine("Welcome to the game");
        // init 2d array with empty strings (3x3)
        string[,] gameBoard = new string[3, 3]
        {
            { " ", " ", " " },
            { " ", " ", " " },
            { " ", " ", " " }
        };
        // show initial game board
        ProcessBoard CurrentBoard = new ProcessBoard(gameBoard);
        CurrentBoard.PrintBoard();
        // init player turn (state that stores whose turn it is)
        bool player1Turn;
        int row;
        int col;
        int turn = 1;

        while (turn <= 9) // once turn is above 9 it is a draw
        {
            player1Turn = (turn % 2 == 1); // sets whose turn it is
            // ask player for choice row then column
            Console.WriteLine($"Player {(player1Turn ? "1" : "2")}, enter your choice row (1-3): ");
            while (true)
            {
                try
                {
                    row = int.Parse(Console.ReadLine());
                    if (row >= 1 && row <= 3)
                    {
                        bool taken = true; // assume whole row is full until proven otherwise
                        for (int i = 0; i < 3; i++)
                        {
                            if (gameBoard[row - 1, i] == " ") // iterate over the row to find an empty space
                            {
                                taken = false;
                                break; // break out of the loop if you find an empty space
                            }
                        }
                        if (!taken)
                        {
                            break;
                        }
                        else // whole row is full
                        {
                            Console.WriteLine("Row is full, choose another row.");
                        }
                    }
                }
                catch // empty catch block
                {
                }
                Console.WriteLine("Invalid input. Please enter a row number 1 - 3.");
            }
            Console.WriteLine($"Player {(player1Turn ? "1" : "2")}, enter your choice column (1-3): ");
            while (true)
            {
                try
                {
                    col = int.Parse(Console.ReadLine());
                    if (col >= 1 && col <= 3)
                    {
                        if (gameBoard[row - 1, col - 1] != " ")
                        {
                            Console.WriteLine("That space is taken, choose another column.");
                        }
                        else
                        {
                            break;
                        }
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
            CurrentBoard = new ProcessBoard(gameBoard);
            // check for win (call method)
            if (CurrentBoard.CheckWin()) // CheckWin returns a boolean
            {
                Console.WriteLine($"Player {(player1Turn ? "1" : "2")} wins!");
                return; // end the game
            }
            Console.WriteLine("Current Game Board");
            CurrentBoard.PrintBoard();
            turn++; // increment turn
        }
        if (turn == 10)// if there is no winner by turn 10 it is a tie
        {
            Console.WriteLine("It's a tie!");
        }
    }
}
