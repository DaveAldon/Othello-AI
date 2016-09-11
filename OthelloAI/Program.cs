using System;

namespace OthelloAI
{
	class MainClass
	{
		public int[,] GameBoard = new int[8, 8];
		public int white = 1;
		public int black = 2;
		public int empty = 0;
		public int side = 0;

		void displayBoard()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int ii = 0; ii < 8; ii++)
				{
					Console.Write(Convert.ToString(GameBoard[i, ii]) + " ");
					if (ii != 0 && ii % 7 == 0) //Simple way of making it look nice in output for now, might be a better way later
					{
						Console.Write("\n");
					}
				}
			}
		}

		public void setStarterPieces() //Changes the board via simple coordinates of the center pieces
		{
			GameBoard[0, 0] = black;
			GameBoard[0, 1] = white;
			GameBoard[3, 4] = black;
			GameBoard[3, 3] = white;
			GameBoard[4, 4] = white;
			GameBoard[4, 3] = black;
		}

		bool isMoveValid(int xcord, int ycord, int color)
		{
			bool isValid = false;
			if (xcord < 0 || xcord > 7) isValid = false;
			if (ycord < 0 || ycord > 7) isValid = false;
			if ((GameBoard[xcord,ycord] == black) || (GameBoard[xcord, ycord] == white)) isValid = false;

				//if (checkDirection(color, xcord, ycord, -1, 1))
				//{
					int y = ycord - 2;
					for (int x = xcord + 2; x > 7; x++)
					{
						if (color == white)
						{
							if (GameBoard[x, y] == white) { isValid = true; }
							else if (GameBoard[x, y] == black) { continue; }
							else if (GameBoard[x, y] == empty) { isValid = false; }
						}
						else if (color == black)
						{
							if (GameBoard[x, y] == black) { isValid = true; }
							else if (GameBoard[x, y] == white) { continue; }
							else if (GameBoard[x, y] == empty) { isValid = false; }
						}
						y--;
				//	}
				}

				//if (checkDirection(color, xcord, ycord, 1, -1))
				//{
					int y2 = ycord + 2;
					for (int x = xcord - 2; x >= 0; x--)
					{
						if (color == white)
						{
							if (GameBoard[x, y2] == white) isValid = true;
							else if (GameBoard[x, y2] == black) continue;
							else if (GameBoard[x, y2] == empty) isValid = false;
						}
						else if (color == black)
						{
							if (GameBoard[x, y2] == black) { isValid = true; }
							else if (GameBoard[x, y2] == white) { continue; }
							else if (GameBoard[x, y2] == empty) { isValid = false; }
						}
					y2++;
			//	}
			}
			return isValid;
		}

		/*
		bool checkDirection(int color, int x, int y, int x2, int y2)
		{
			if ((color == black) && (GameBoard[x + x2, y + y2] == white)) return true;
			if ((color == white) && (GameBoard[x + x2, y + y2] == black)) return true;
			else return false;
		}
		*/

		public int[,] transformInput(int color)
		{
			bool valid = false;
			int x = 0;
			int y = 0;
			int[,] inputBoard = new int[8, 8];
			inputBoard = GameBoard;

			while (!valid)
			{
				Console.Write("Enter the first dimension:\n");
				x = Convert.ToInt16(Console.ReadLine());
				Console.Write("Enter the second dimension:\n");
				y = Convert.ToInt16(Console.ReadLine());

				 if (isMoveValid(x, y, side)) 
				{
					inputBoard[x, y] = color;
					valid = true;
				}
				else 
				{
					Console.Write("Move won't flip any pieces, try again\n");
					continue;
				}
			}
			return inputBoard;
		}

		void setActivePlayer(int color)
		{
			if (color == white)
			{
				side = white;
				Console.Write("White's move\n");
			}
			else {
				side = black;
				Console.Write("Black's move\n");
			}
		}

		void makeMove(int side)
		{
			GameBoard = transformInput(side);
			if (side == black)
			{
				side = white;
			}
			else {
				side = black;
			}
		}

		void RunGame()
		{
			Console.Write("Who is going first, 1 or 2: \n");
			setActivePlayer(Convert.ToInt16(Console.ReadLine()));
			setStarterPieces();
			displayBoard();

			int gameOver = 0;

			while (gameOver != 1)
			{
				makeMove(side);
				displayBoard();
			}

		}

		public static void Main(string[] args)
		{
			MainClass Othello = new MainClass();
			Othello.RunGame();
		}
	}
}
