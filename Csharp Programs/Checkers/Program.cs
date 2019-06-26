using System;

namespace Checkers
{
    struct Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
    enum Color
    {
        Red, Green
    }

    class Checker
    {
        public string Symbol { get; private set; }
        public Position position { get; set; }
        public Color Team { get; private set; }
        public bool King { get; set; }
        public Checker(Color team, int row, int col)
        {
            Symbol = "O";
            Team = team;
            King = false;
            position = new Position(row, col);
        }
        public Checker(Color team, int row, int col, bool king)
        {
            Symbol = "K";
            Team = team;
            King = king;
            position = new Position(row, col);
        }
        
    }

    class Board
    {
        public object[][] GameBoard;
        int RedPieces;
        int GreenPieces;
        public bool RedWin {get; set;}
        public bool GreenWin { get; set; }
        public Board()
        {
            GreenWin = false;
            RedWin = false;
            GameBoard = new object[8][];
            for (int x = 0; x < 8; x++)
            {
                GameBoard[x] = new object[8];
            }

            for (int y = 0; y < 3; y++)
            {
                if (y % 2 == 0)
                {
                    for (int x = 0; x < 8; x += 2)
                    {
                        Checker temp = new Checker(Color.Green, x, y);
                        GameBoard[y][x] = temp;
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x += 2)
                    {
                        Checker temp = new Checker(Color.Green, x, y);
                        GameBoard[y][x] = temp;
                    }
                }
            }
            for (int y = 7; y > 4; y--)
            {
                if (y % 2 == 0)
                {
                    for (int x = 0; x < 8; x += 2)
                    {
                        Checker temp = new Checker(Color.Red, x, y);
                        GameBoard[y][x] = temp;
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x += 2)
                    {
                        Checker temp = new Checker(Color.Red, x, y);
                        GameBoard[y][x] = temp;
                    }
                }
            }
        }
        public void InitializeBoard()
        {
            GreenPieces = 0;
            RedPieces = 0;
            Console.Write("   0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 \n" +
                          "----------------------------------");
            for (int y = 0; y < 8; y++)
            {
                Console.Write($"\n{y}|");
                for (int x = 0; x < 8; x++)
                {
                    if (GameBoard[y][x] != null)
                    {
                        Checker temp = (Checker)GameBoard[y][x];
                        if (temp.Team == Color.Green)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" O ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                            GreenPieces++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" O ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                            RedPieces++;
                        }
                    }
                    else
                    {
                        Console.Write("   |");
                    }
                }
                Console.Write("\n---------------------------------");
            }
            if(GreenPieces == 0)
            {
                RedWin = true;
            }
            else if(RedPieces == 0)
            {
                GreenWin = true;
            }
        }
        public void MovePiece(Color Player)
        {
            
            int sx = 0, sy = 0, dx = 0, dy = 0;
            bool succ = false;
            while (!succ)
            {
                Console.Clear();
                InitializeBoard();
                if (!GetSource()) continue;
                if(!GetDestination()) continue;
                if(!PerformMove()) continue;
                succ = true;
            }

            //validate source ,is not null, and source correct player team
            //validate move is legal, check is space is occupied by ally, check if space is occupied by opponent



            bool GetSource()
            {
                try
                {
                    Console.WriteLine($"\n{Player} Player Please choose a piece to move.");
                    Console.Write($"X coordinate: ");
                    sx = int.Parse(Console.ReadLine());
                    while (sx < 0 || sx > 7)
                    {
                        Console.Write($"X Coordinate, must be between 0 and 7. \nX coordinate: ");
                        sx = int.Parse(Console.ReadLine());
                    }
                    Console.Write($"Y Coordinate: ");
                    sy = int.Parse(Console.ReadLine());
                    while (sy < 0 || sy > 7)
                    {
                        Console.Write($"Y Coordinate, must be between 0 and 7. \nY coordinate: ");
                        sy = int.Parse(Console.ReadLine());
                    }
                    if (GameBoard[sy][sx] == null)
                    {
                        Console.Write("You choose an empty square. Please rechoose your piece.\n" +
                            "Press any key to choose again...");
                        Console.ReadLine();
                        return false;
                    }
                    Checker temp = (Checker)GameBoard[sy][sx];
                    if (temp.Team != Player)
                    {
                        Console.Write("You choose an opponents piece. Please rechoose your piece.\n" +
                            "Press any key to choose again...");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                catch (FormatException)
                {
                    Console.Write("You entered an letter instead of a number. Please reenter you source using numbers 0-7" +
                        "Press any key to choose again...");
                    Console.ReadLine();
                    return false;
                }
                
            }
            bool GetDestination()
            {
                try
                {

                    Console.Write($"{Player} Player Please choose where to move your piece\n" +
                    $"X coordinate: ");
                    dx = int.Parse(Console.ReadLine());
                    while (dx < 0 || dx > 7)
                    {
                        Console.Write($"X Coordinate, must be between 0 and 7. \nX coordinate: ");
                        dx = int.Parse(Console.ReadLine());
                    }
                    Console.Write($"Y Coordinate: ");
                    dy = int.Parse(Console.ReadLine());
                    while (dy < 0 || dy > 7)
                    {
                        Console.Write($"Y Coordinate, must be between 0 and 7. \nY coordinate: ");
                        dy = int.Parse(Console.ReadLine());
                    }
                    return true;
                }
                catch (FormatException)
                {
                    Console.Write("You entered an letter instead of a number. Please reenter you destination using numbers 0-7" +
                        "Press any key to choose again...");
                    Console.ReadLine();
                    return false;
                }
            }
            bool PerformMove()
            {
                int Ydirection = 0; //will hold direction of play
                if (Player == Color.Red) //if player is red
                    Ydirection-= 1; //move up
                else Ydirection += 1;//else move down
                
                    if ((dx == sx + 1)) { }// if x destination is 1 greater, move is valid 
                    else if (dx == sx - 1) { } // if x destination is 1 lesser move is valid
                    else//x destination was neither 1 greater nor 1 lesser, move invalid, restart turn
                    {
                        Console.Write("You piece may only move in a forward diagonal direction.\n" +
                          " Your X coordinate did not fit this rule. \n" +
                          "Press any key to choose again...");
                        Console.ReadLine();
                        return false;
                }

                    if ((dy != sy+Ydirection))//if y destination is not 1 step in the direction of play restart turn
                    {
                        Console.Write("You piece may only move in a forward diagonal direction.\n" +
                           " Your Y coordinate did not fit this rule.\n"+
                           "Press any key to choose again...");
                        Console.ReadLine();
                        return false;
                    }
                if (GameBoard[dy][dx] != null) //if destionation is not empty
                {
                    Checker temp = (Checker)GameBoard[dy][dx]; //set temp to unbox the contents in destination
                    if (temp.Team == Player)// if temp is players own color rechoose turn
                    {
                        Console.WriteLine("You tried to move your piece on to a space that was occupied by your own piece\n" +
                            "Press any key to choose again");
                        Console.ReadLine();
                        return false;
                    }
                    if (temp.Team != Player)// if temp is opponent jump
                    {
                        if (dx - 1 < 0) //if trying to jump an left edge piece restart turn
                        {
                            Console.WriteLine("You tried to jump a piece at the edge of the board. This is an invalid move\n" +
                                "Press any key to choose again.");
                            Console.ReadLine();
                            return false;
                        }
                        else if (dx + 1 > 7)//if trying to jump an right edge piece restart turn
                        {
                            Console.WriteLine("You tried to jump a piece at the edge of the board. This is an invalid move\n" +
                                "Press any key to choose again.");
                            Console.ReadLine();
                            return false;
                        }
                        else if ((Player == Color.Red && dy + Ydirection < 0) || (Player == Color.Green && dy + Ydirection > 7))//if trying to jump an top(red) or bottom(Green) piece restart turn
                        {
                            Console.WriteLine("You tried to jump a piece at the edge of the board. This is an invalid move\n" +
                                "Press any key to choose again.");
                            Console.ReadLine();
                           return false;
                        }
                        else if (dx == sx + 1) //if jumping from right
                        {
                            if (GameBoard[dy + Ydirection][dx + 1] != null)//if new destination is occupied restart turn
                            {
                                Console.WriteLine("You tried to jump a opponents piece, but the space behind it is occupied.\n" +
                                    " Press any key to choose again...");
                                Console.ReadLine();
                                return false;
                            }
                            GameBoard[dy][dx] = null; //remove opponent piece
                            GameBoard[sy][sx] = null; //remove source piece
                            dx += 1; dy += Ydirection; //set new destination
                            if (Player == Color.Red && dy == 0)
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Red King piece
                            }
                            else if(Player == Color.Green && dy == 7)
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Green king piece
                            }
                            else
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy); //place new normal piece
                            }
                            
                            return true;
                        }
                        else if (dx == sx - 1) //if jumping from left
                        {
                            if (GameBoard[dy + Ydirection][dx - 1] != null)//if new destination is occupied restart turn
                            {
                                Console.WriteLine("You tried to jump a opponents piece, but the space behind it is occupied.\n" +
                                    " Press any key to choose again...");
                                Console.ReadLine();
                                return false;
                            }
                            GameBoard[dy][dx] = null; //remove opponent piece
                            GameBoard[sy][sx] = null; //remove source piece
                            dx -= 1; dy += Ydirection; //set new destination
                            if (Player == Color.Red && dy == 0)
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Red King piece
                            }
                            else if (Player == Color.Green && dy == 7)
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Green king piece
                            }
                            else
                            {
                                GameBoard[dy][dx] = new Checker(Player, dx, dy); //place new piece
                            }
                            return true;
                        }
                    }
                }
                else//if destination space is unoccupied
                {
                    if (Player == Color.Red && dy == 0)
                    {
                        GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Red King piece
                    }
                    else if (Player == Color.Green && dy == 7)
                    {
                        GameBoard[dy][dx] = new Checker(Player, dx, dy, true); //place new Green king piece
                    }
                    else
                    {
                        GameBoard[dy][dx] = new Checker(Player, dx, dy); // set destination piece
                    }
                    GameBoard[sy][sx] = null; //remove source piece
                    return true;
                }
                return false;
                }
                
            }
        }
    
    class Program
    {
        static void Main(string[] args)
        {
            Color Player = Color.Red;
            bool winner = false;
            Color CWinner = Color.Red;
            Board Game = new Board();
            while(!winner)
            {
                if (Player == Color.Red)
                {
                    Game.MovePiece(Player);
                    Player = Color.Green;
                        if (Game.RedWin)
                        {
                            winner = Game.RedWin;
                            CWinner = Color.Red;
                        }
                    }
                else
                {
                    Game.MovePiece(Player);
                    Player = Color.Red;
                        if (Game.GreenWin)
                        {
                            winner = Game.GreenWin;
                            CWinner = Color.Green;
                        }
                }

            }
            Console.Write($"{CWinner} You win!");
            Console.Read();
        }
    }
}
