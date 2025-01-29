namespace Mission4;

public class ProcessBoard // PascalCase is the C# naming convention
{
    // use a private string 2d array to store the state of the class
    private string[,] _board;
    // public constructor to allow instantiation outside of the class
    public ProcessBoard(string[,] gameBoard)
    {
        _board = gameBoard;
    }
    public void PrintBoard() // does not need an argument because it is working with the state of the class (_board)
    {
        // fills blanks in_board with spaces
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[i, j] == "")
                {
                    _board[i, j] = " ";
                }

            }
        }

        // prints_board with vertical spacers
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (j > 1)
                {
                    Console.WriteLine(_board[i, j]);
                }
                else
                {
                    Console.Write(_board[i, j] + " | ");
                }

            }

        }

    }

    public bool CheckWin() // does not need a gameBoard argument because it is working with the state of the class (_board)
    {
        string checkValue = "";
        int matchCount = 0;
        bool result = false;
        // check rows
        // filters through_board
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            // sets value of first square to check against
            if (_board[i, 0] != " ")
            {
                checkValue = _board[i, 0];
            }

            // filters through row, checks against first value
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[i, j] == checkValue)
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
        // filters through columns in_board
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            // sets value of first square to check against
            if (_board[0, i] != " ")
            {
                checkValue = _board[0, i];
            }

            // filters through values in column, checks against first value
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[j, i] == checkValue)
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
        if (_board[1, 1] != " ")
        {
            checkValue = _board[1, 1];
        }

        // check if two corners in one direction match
        if (_board[0, 0] == checkValue && _board[2, 2] == checkValue)
        {
            result = true;
        }
        else if (_board[0, 2] == checkValue && _board[2, 0] == checkValue) // check if 2 corners in other direction match
        {
            result = true;
        }

        return result;
    }
}