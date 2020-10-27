using System;

public class Game
{
	List<int[]> Cards;
	int[] elems;
	
	public Game(int[] elems)
	{
	}

	private List<int[]> GenerateCards()
    {
		List<int[]> Cards = new List<int[]>();

		NumberOfElems = Math.Ceiling(Math.Sqrt(this.elems.Length + this.elems.Length - 1));
		//create first card
		int[] first = new int[NumberOfElems];
		for(int i = 0; i<NumberOfElems; i++)
        {
			first[i] = this.elems[i];
        }
		Cards.add(first);

		//create a card beginning with each element in the first card
		int count = 0;
		foreach(int firstElem in first){
			count++;
			for (int i = 1; i<NumberOfElems; i++)
            {
				int[] card = new int[NumberOfElems];
				card[0] = firstElem;
				for (int j = 1;  j<NumberOfElems; j++)
                {
					if (count == 1) 
						card[i] = this.elems[i * NumberOfElems + j];
					else if (count == 2){
						card[i] = this.elems[j * NumberOfElems + i];
					}
					else 
                    {
						card[i] = this.elems[j*NumberOfElems+((count*j+i) % NumberOfElems)];
					}
				}
				Cards.add(card);
			}
        }
		return Cards;
	}
}
