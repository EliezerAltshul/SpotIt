using System;

public class Game
{
	List<int[]> Deck;		//a deck of cards
	int[] elems;			//an array of elements on the cards
	
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
		NumberOfElems = Math.Ceiling(Math.Sqrt(this.elems.Length));

		//create the first card
		int[] first = new int[NumberOfElems];
		for(int i = 0; i<NumberOfElems; i++)
        {
			first[i] = this.elems[i];
        }
		Cards.add(first);

		int count = 0;
		foreach(int firstElem in first){
			count++;
			for (int i = 1; i<NumberOfElems; i++)
            {
				//create a card beginning with each element in the first card
				int[] card = new int[NumberOfElems];
				card[0] = firstElem;
				for (int j = 1;  j<NumberOfElems; j++)
                {
					//for the first set of cards, simply create add the next NumberOfElems in elem
					if (count == 1) 
						card[i] = this.elems[i * NumberOfElems + j];
					//all the rest of the cards have the next NumberOfElems, 
					//but the space incrementally gets larger
					else
					{
						//I am not certain about this code
						card[i] = this.elems[j*NumberOfElems+(((count-2)*j+i) % NumberOfElems)];
					}
				}
				Cards.add(card);
			}
        }
		return Cards;
	}
}
