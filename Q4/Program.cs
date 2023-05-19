using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int rows = 1;
        int columns = 1;
        Stack<Tuple<int, int>> undoStack = new Stack<Tuple<int, int>>();
        Stack<Tuple<int, int>> redoStack = new Stack<Tuple<int, int>>();

        while (true)
        {
            int move = int.Parse(Console.ReadLine());

            if (move == 11)
            {
                break;
            }
            else if (move == 9 && undoStack.Count > 0)
            {
                Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                Tuple<int, int> previousMove = undoStack.Pop();
                rows = previousMove.Item1;
                columns = previousMove.Item2;
                redoStack.Push(temp);
                continue;
            }
            else if (move == 10 && redoStack.Count > 0)
            {
                Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                Tuple<int, int> nextMove = redoStack.Pop();
                rows = nextMove.Item1;
                columns = nextMove.Item2;
                undoStack.Push(temp);
                continue;
            }
            else if (move >= 1 && move <= 8)
            {
                int x = int.Parse(Console.ReadLine());
                bool canMove = CheckMove(move, rows, columns, x);

                if (canMove)
                {
                    Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                    undoStack.Push(temp);
                    Move(move, ref rows, ref columns, x);
                    redoStack.Clear();
                }
                continue;
            }
            else
            {
                Console.WriteLine("Invalid move. Please try again.");
            }
        }

        Console.WriteLine($"{Convert.ToChar(columns - 1 + 'A')} {rows}");
    }

    static bool CheckMove(int action, int rows, int columns, int x)
    {
        switch (action)
        {
            case 1:
                return rows + x <= 8;
            case 2:
                return rows + x <= 8 && columns - x >= 1;
            case 3:
                return columns - x >= 1;
            case 4:
                return rows - x >= 1 && columns - x >= 1;
            case 5:
                return rows - x >= 1;
            case 6:
                return rows - x >= 1 && columns + x <= 8;
            case 7:
                return columns + x <= 8;
            case 8:
                return rows + x <= 8 && columns + x <= 8;
            default:
                return false;
        }
    }

    static void Move(int action, ref int rows, ref int columns, int x)
    {
        switch (action)
        {
            case 1:
                rows += x;
                break;
            case 2:
                rows += x;
                columns -= x;
                break;
            case 3:
                columns -= x;
                break;
            case 4:
                rows -= x;
                columns -= x;
                break;
            case 5:
                rows -= x;
                break;
            case 6:
                rows -= x;
                columns += x;
                break;
            case 7:
                columns += x;
                break;
            case 8:
                rows += x;
                columns += x;
                break;
        }
    }
}
