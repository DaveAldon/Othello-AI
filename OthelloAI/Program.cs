using System;

namespace OthelloAI
{
	class MainClass
	{
		public int[,] GameBoard = new int[8, 8];

		void displayBoard()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int ii = 0; ii < 8; ii++)
				{
					Console.Write(Convert.ToString(GameBoard[i, ii]));
					if (ii != 0 && ii % 7 == 0) //Simple way of making it look nice in output for now, might be a better way later
					{
						Console.Write("\n");
					}
				}
			}
		}

		public static void Main(string[] args)
		{
			MainClass Othello = new MainClass();	
			Othello.displayBoard();
		}
	}
}
