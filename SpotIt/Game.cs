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
			int NumberOfElems = (int)Math.Ceiling(Math.Sqrt(this.elems.Length));

			//create the first card
			int[] first = new int[NumberOfElems];
			for (int i = 0; i < NumberOfElems; i++)
			{
				first[i] = this.elems[i];
			}
			Cards.Add(first);

			int count = 0;
			foreach (int firstElem in first)
			{
				count++;
				for (int i = 0; i < NumberOfElems-2; i++)
				{
					//create a card beginning with each element in the first card
					int[] card = new int[NumberOfElems];
					card[0] = firstElem;
					for (int j = 0; j < NumberOfElems-2; j++)
					{
						//for the first set of cards, simply create add the next NumberOfElems in elem
						if (count == 1)
							card[j+1] = this.elems[NumberOfElems + NumberOfElems * i + j];
						//all the rest of the cards have the next NumberOfElems, 
						//but the space incrementally gets larger
						else
						{
							//I am not certain about this code
							card[j] = this.elems[NumberOfElems + NumberOfElems * j + (count * j + i) % NumberOfElems];
						}
					}
					Cards.Add(card);
				}
			}
			return Cards;
		}
	}
}
