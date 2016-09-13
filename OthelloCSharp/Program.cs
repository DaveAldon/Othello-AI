using System;

namespace OthelloAI
{
	class MainClass
	{
		public const int _SIZE = 8;
		public int[,] GameBoard = new int[_SIZE, _SIZE];
		public int white = 1;
		public int black = -1;
		public int empty = 0;
		public int side = 0;

		void displayBoard()
		{
			for (int i = 0; i < _SIZE; i++)
			{
				for (int ii = 0; ii < _SIZE; ii++)
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

		public bool spaceValid(int x, int y)
		{
			if (x < 0 || y < 0 || x >= _SIZE || y >= _SIZE) return false;
			else return true;
		}

		public int moveValue(int x, int y, int color)
		{
			//If the space is occupied, return 0
			if (GameBoard[x, y] != empty) return 0;

			int value = 0;
			int xDirection; //Horizontal direction
			int yDirection; //Vertical direction
			int distance; //Distance
			int xTemp;
			int yTemp;

			for (xDirection = -1; xDirection <= 1; xDirection++)
			{
				for (yDirection = -1; yDirection <= 1; yDirection++)
				{
					if (!(xDirection == 0 && yDirection == 0))
					{
						distance = 1;
						xTemp = x + xDirection;
						yTemp = y + yDirection;
						while (spaceValid(xTemp, yTemp) && GameBoard[xTemp, yTemp] == -color)
						{
							distance++;
							xTemp += xDirection;
							yTemp += yDirection;
						}
						if (distance > 1 && spaceValid(xTemp, yTemp) && GameBoard[xTemp, yTemp] == color)
							value += distance - 1;
					}
				}
			}
			return value;
		}





		public int[,] transformInput(int color)
		{
			bool valid = false;
			int x = 0;
			int y = 0;
			int[,] inputBoard = new int[_SIZE, _SIZE];
			inputBoard = GameBoard;

			while (!valid)
			{
				Console.Write("Enter the first dimension:\n");
				x = Convert.ToInt16(Console.ReadLine());
				Console.Write("Enter the second dimension:\n");
				y = Convert.ToInt16(Console.ReadLine());

				if(moveValue(x, y, color) > 0)
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

		void makeMove(int color)
		{
			GameBoard = transformInput(side);
			if (color == black)
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
