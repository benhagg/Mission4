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
        // filters through board
        for (int i = 0; i < board.GetLength(0); i++)
        {
            // sets value of first square to check against
            if (board[i, 0] != " ")
            {
                checkValue = board[i, 0];
            }
            
            // filters through row, checks against first value
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == checkValue)
                {
                    matchCount++;
                }
            }
            
            // checks if there are 3 matching values
            if (matchCount >= 3)
            {
                result = true;
            }

            matchCount = 0;
        }
        // check columns
        // filters through columns in board
        for (int i = 0; i < board.GetLength(0); i++)
        {
            // sets value of first square to check against
            if (board[0, i] != " ")
            {
                checkValue = board[0, i];
            }
            
            // filters through values in column, checks against first value
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[j, i] == checkValue)
                {
                    matchCount++;
                }
            }
            
            // checks if there are 3 matching values
            if (matchCount >= 3)
            {
                result = true;
            }

            matchCount = 0;
        }

        
        // check diagonal
        // reset checkvalue
        checkValue = "";
        // set middle value to check against
        if (board[1, 1] != " ")
        {
            checkValue = board[1, 1];
        }
    
        // check if two corners in one direction match
        if (board[0, 0] == checkValue && board[2, 2] == checkValue)
        {
            result = true;
        } else if (board[0, 2] == checkValue && board[2, 0] == checkValue) // check if 2 corners in other direction match
        {
            result = true;
        }
        
        return result;
    }
}