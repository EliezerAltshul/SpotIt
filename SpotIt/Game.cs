using System;
using System.Collections.Generic;

namespace SpotIt {
	public class Game
	{
		public List<int[]> Deck;        //a deck of cards
		public int[] elems;         //an array of elements on the cards

		//a constructer asking for an array of elements
		public Game(int[] elems)
		{
			this.elems = elems;
			this.Deck = GenerateCards();
		}

		private List<int[]> GenerateCards()
		{
			List<int[]> Cards = new List<int[]>();

			//find the number of elements on each card
			//n is the number of elements in each card
			int n = (int)Math.Ceiling(Math.Sqrt(this.elems.Length)) - 1;

			//create the first card
			int[] first = new int[n+1];
			for (int i = 0; i <= n; i++)
			{
				first[i] = this.elems[i];
			}
			Cards.Add(first);

			int firstElem = 0;
			for(int i = 0; i<n+1; i++)
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
							//I am not certain about this code
							card[k+1] = this.elems[n + 1 + n * k + (i * k + j) % n];
						}
					}
					Cards.Add(card);
				}
			}
			return Cards;
		}
	}
}
