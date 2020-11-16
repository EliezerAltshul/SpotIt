using System;
using System.Collections.Generic;

namespace SpotIt {

	public class Game
	{
		public List<int[]> Cards;        //a deck of cards
		public Stack<int[]> Deck;
		public int[] elems;         //an array of elements on the cards
		public int numbOfElem;

		//a constructer asking for an array of elements
		public Game(int numbOfElem)
		{
			this.numbOfElem = numbOfElem;
			this.Cards = ShuffleDeck(GenerateCards(numbOfElem - 1));
			this.Deck = GenerateDeck(Cards);
		}
		
		private Stack<int[]> GenerateDeck(List<int[]> Cards)
        {
			Stack<int[]> stack = new Stack<int[]>();
			
			foreach(int[] card in Cards)
            {
				stack.Push(card);

			}

			return stack;
		}

		private List<int[]> ShuffleDeck(List<int[]> list)
		{
			Random rng = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				int[] value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
			return list;
		}


		private List<int[]> GenerateCards(int n){
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
					
					Random rng = new Random();
					int length = card.Length;
					while (length > 1)
					{
						int k = rng.Next(length--);
						int temp = card[n];
						card[n] = card[k];
						card[k] = temp;
					}

					Cards.Add(card);
				}
			}
			return Cards;
		}
		public bool SpotMatch(int input, int[] cardOne, int[] cardTwo)
        {
			int match = CompareCards(cardOne, cardTwo);
			return input == match;

		}
		public int CompareCards(int[] cardOne, int[] cardTwo)
		{

			int matchingElement = 0;
			for (int i = 0; i < cardOne.Length; i++)
			{
				for (int j = 0; j < cardTwo.Length; j++)
				{
					if (cardOne[i] == cardTwo[j])
					{
						matchingElement = cardOne[i];
					}
				}
			}
			return matchingElement;
		}
	}
}
