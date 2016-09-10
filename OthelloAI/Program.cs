using System;

namespace OthelloAI
{
	class MainClass
	{
		public int[,] GameBoard = new int[8, 8];
		public int white = 1;
		public int black = 2;
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

		public void setStarterPieces()
		{
			GameBoard[3, 4] = black;
			GameBoard[3, 3] = white;
			GameBoard[4, 4] = white;
			GameBoard[4, 3] = black;
		}

		public int[,] transformInput(int color)
		{
			bool valid = false;
			int A = 0;
			int B = 0;
			int[,] inputBoard = new int[8, 8];
			inputBoard = GameBoard;

			while (!valid)
			{
				A = Convert.ToInt16(Console.ReadLine());
				B = Convert.ToInt16(Console.ReadLine());

				if (inputBoard[A, B] != 0)
				{
					Console.Write("Spot is taken, try again\n");
					continue;
				}
				else {
					inputBoard[A, B] = color;
					valid = true;
				}
			}
			return inputBoard;
		}

		int setActivePlayer(int whiteOrBlack)
		{
			int activePlayer = 1;
			if (whiteOrBlack == 2)
			{
				activePlayer = whiteOrBlack;
				Console.Write("White's move\n");
			}
			else {
				Console.Write("Black's move\n");
			}
			return activePlayer;
		}

		void makeMove(int activePlayer)
		{
			GameBoard = transformInput(activePlayer);
			if (side == 1)
			{
				side = 2;
			}
			else {
				side = 1;
			}
		}

		void RunGame()
		{
			Console.Write("Who is going first, 1 or 2: \n");
			side = setActivePlayer(Console.Read());
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
