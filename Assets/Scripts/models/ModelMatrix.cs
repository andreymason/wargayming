using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMatrix : MonoBehaviour{
    int [,] mainMatrix = new int [8,8]; //[num,sym]
    public bool[,] turn = new bool[8,8];
    ChipSpawner cp;

    private void Start()
    {
        cp = gameObject.GetComponent<ChipSpawner>();

        mainMatrix[3,3] = 1;
        mainMatrix[4,4] = 1;
        mainMatrix[3,4] = -1;
        mainMatrix[4,3] = -1;
        cp.SpawnChip((Alpha)3,4,Color.White);
        cp.SpawnChip((Alpha)4,5,Color.White);
        cp.SpawnChip((Alpha)3,5,Color.Black);
        cp.SpawnChip((Alpha)4,4,Color.Black);
    }

    public bool AddValueToMainMatrix(Alpha sym, int num, Color color){
        Debug.Log("Adding value" + num + ":" + sym);
        PossibleTurnsMatrix(color);
        if(turn[num - 1, (int)sym]){
            if(color == Color.Black){
                mainMatrix[num - 1, (int)sym] = -1;
            }
            else{
                mainMatrix[num - 1, (int)sym] =  1;
            }
            cp.SpawnChip(sym,num,color);
            AudioManager.Play(AudioClipName.chip);
            return true;
        }
        return false;
    }
    
    public void PossibleTurnsMatrix (Color color)
	{
		sbyte igrock;
		if(color ==Color.White)
			igrock = 1;
		else
			igrock = -1;

		//происзодит заполнение матрицы возможных ходов
		for (byte i = 0; i < 8; i++)
			for (byte j = 0; j < 8; j++)
			{
				if (igrock == mainMatrix [i, j]) 
				{
					est_li_hod (mainMatrix [i, j], i, j);
				} 
				else 
				{
					continue;
				}
			}
	}

	void est_li_hod (int igroc_color, int num, int sym)
	{
		//вверх
		if (num > 0 && igroc_color == (-mainMatrix [num - 1, sym])) //проверка, есть ли сверху фишка противоположного цвета (и фишка должна біть не на краю доски)
		{ 
			for (int i = num - 1; i >= 0; i--) //иду вверз от текущей позиции
			{
				if (igroc_color == (mainMatrix [i, sym])) //если встречаю фишку своего цвета до того, как была найдена пустая клетка, походить сверху не выйдет 
				{
					break;
				}
				else if (mainMatrix [i, sym] == 0) //если после всех фишек противоположного цвета есть пустая клетка, значит в неё есть возможность походить
				{
					turn [i, sym] = true; //по координатам клетки ставлю тру (ходить туда можно)
					break;
				}
			}
		} else {} //если не ставить иногда начинается какая то катовсия с ифами, на всякий пожарній крч

		//остальное аналогично, меняется только сторона, "куда я иду проверять"

		//вверх-вправо
		if (num > 0 && sym < 7 && igroc_color == (-mainMatrix [num - 1,sym + 1]))
		{
			for (int i = num - 1, j = sym + 1; i >= 0 && j < 8; i--, j++) {
				if (igroc_color == (mainMatrix [i, j])) 
				{ 
					break;
				}
				else if (mainMatrix [i, j] == 0) 
				{ 
					turn [i, j] = true; 
					break;
				}
			}
		} else {}


		//вправо
		if (sym < 7 && igroc_color == (-mainMatrix [num,sym + 1]))
		{
			for (int i = sym + 1; i < 8; i++) 
			{
				if (igroc_color == (mainMatrix [num, i]))
				{
					break;
				}
				else if (mainMatrix [num, i] == 0) 
				{
					turn [num, i] = true; 
					break;
				}
			}
		} else {}


		//вниз-вправо
		if (num < 7 && sym < 7 && igroc_color == (-mainMatrix [num + 1,sym + 1]))
		{
			for (int i = num + 1, j = sym + 1; i < 8 && j < 8; i++, j++) {
				if (igroc_color == (mainMatrix [i, j]))
				{
					break;
				}
				else if (mainMatrix [i, j] == 0) 
				{ 
					turn [i, j] = true; 
					break;
				} 
			}
		} else {}


		//вниз
		if (num < 7 && igroc_color == (-mainMatrix [num + 1,sym]))
		{
			for (int i = num + 1; i < 8; i++) 
			{
				if (igroc_color == (mainMatrix [i, sym])) 
				{
					break;
				}
				else if (mainMatrix [i, sym] == 0)
				{
					turn [i, sym] = true;
					break;
				}
			}
		} else {}


		//вниз-влево
		if (num < 7 && sym > 0 && igroc_color == (-mainMatrix [num + 1,sym - 1]))
		{
			for (int i = num + 1, j = sym - 1; i < 8 && j >= 0; i++, j--) {
				if (igroc_color == (mainMatrix [i, j]))
				{
					break;
				}
				else if (mainMatrix [i, j] == 0) 
				{
					turn [i, j] = true; 
					break;
				}
			}
		} else {}


		//влево
		if (sym > 0 && igroc_color == (-mainMatrix [num,sym - 1]))
		{
			for (int i = sym - 1; i >= 0; i--) 
			{
				if (igroc_color == (mainMatrix [num, i]))
				{
					break;
				}
				else if (mainMatrix [num, i] == 0) 
				{
					turn [num, i] = true;
					break;
				}
			} 
		} else {}


		//вверх-влево
		if (num > 0 && sym > 0 && igroc_color == (-mainMatrix [num - 1,sym - 1]))
		{
			for (int i = num - 1, j = sym - 1; i >= 0 && j >= 0; i--, j--) {
				if (igroc_color == (mainMatrix [i, j]))
				{
					break;
				}
				else if (mainMatrix [i, j] == 0) 
				{
					turn [i, j] = true; 
					break;
				}
			}
		} else {}
	}
}
