using System;
using System.Collections.Generic;

namespace SpotIt {
	public class Game
	{
		public int[][] Deck;        //a deck of cards
		public int[] elems;         //an array of elements on the cards
		public int numbOfElem;

		//a constructer asking for an array of elements
		public Game(int numbOfElem)
		{
			this.numbOfElem = numbOfElem;
			this.Deck = GenerateCards(numbOfElem-1);
		}

		private int[][] GenerateCards(int n)
		{
			List<int[]> Cards = new List<int[]>();

			this.elems = new int[n * n + n + 1];
			for (int i = 0; i < elems.Length; i++)
				elems[i] = i;

			//create the first card
			int[] first = new int[n+1];
			for (int i = 0; i <= n; i++)
			{
				first[i] = this.elems[i];
			}
			Cards.Add(first);

			int firstElem = 0;
			for(int i = 0; i<=n; i++)
			{
				firstElem = first[i];
				for (int j = 0; j < n; j++)
				{
					//create a card beginning with each element in the first card
					int[] card = new int[n+1];
					card[0] = firstElem;
					for (int k = 0; k < n; k++)
					{
						//for the first set of cards, simply create add the next n in elem
						if (i == 0)
							card[k+1] = this.elems[n + 1 + n * j + k];
						//all the rest of the cards have the next n, 
						//but the space incrementally gets larger
						else
						{
							card[k+1] = this.elems[n + 1 + n * k + (i * k + j) % n];
						}
					}
					Cards.Add(card);
				}
			}
			return Cards.ToArray();
		}
	}
}
