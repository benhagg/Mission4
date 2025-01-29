namespace Mission4;

public class processBoard
{
    public void printBoard(string[,] board)
    {
        // fills blanks in board with spaces
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == "")
                {
                   board[i, j] = " ";
                }
                
            }
        }
        
        // prints board with vertical spacers
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (j > 1)
                {
                    Console.WriteLine(board[i, j]);
                }
                else
                {
                    Console.Write(board[i, j] + " | ");
                }
                
            }
            
        }
        
    }

    public bool checkWin(string[,] board)
    {
        string checkValue = "";
        int matchCount = 0;
        bool result = false;
        // check rows
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (board[i, 0] != " ")
            {
                checkValue = board[i, 0];
            }
            
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == checkValue)
                {
                    matchCount++;
                }
            }
            if (matchCount >= 3)
            {
                result = true;
            }

            matchCount = 0;
        }
        // check columns
        // check diagonal
        return result;
    }
}