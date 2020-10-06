using System;
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
		//start Matrix initialization
        mainMatrix[3,3] = 1;
        mainMatrix[4,4] = 1;
        mainMatrix[3,4] = -1;
        mainMatrix[4,3] = -1;
        cp.SpawnChip(Alpha.D,4,Color.White);
        cp.SpawnChip(Alpha.E,5,Color.White);
        cp.SpawnChip(Alpha.D,5,Color.Black);
        cp.SpawnChip(Alpha.E,4,Color.Black);
    }

    public bool AddValueToMainMatrix(Alpha sym, int num, Color color)
    {
        PossibleTurnsMatrix(color);
        if(turn[num - 1, (int)sym]){
            if(color == Color.Black){
                mainMatrix[num - 1, (int)sym] = -1;
            }
            else{
                mainMatrix[num - 1, (int)sym] =  1;
            }

            turn[num - 1, (int) sym] = false;
            
            cp.SpawnChip(sym,num,color);
            AudioManager.Play(AudioClipName.chip);
            return true;
        }
        return false;
    }
    
    //fills the possible turns matrix for the given player color
    public void PossibleTurnsMatrix (Color color)
    {
        for (byte i = 0; i < 8; i++)
			for (byte j = 0; j < 8; j++)
            {
                if (mainMatrix[i, j] == 0)
                {
                    IsTurnPossibleUpdate(color == Color.White? 1 : -1, i, j);
                }
                else continue;
            }
	}

    /// <summary>
    /// checks whether the turn move is possible
    /// </summary>
    /// <param name="playerColor"></param>
    /// <param name="num"></param>
    /// <param name="sym"></param>
	void IsTurnPossibleUpdate (int playerColor, int num, int sym)
    {
        turn[num, sym] = false;
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            int skaX = directionToCoordinate(direction, 'x');
            int skaY = directionToCoordinate(direction, 'y');
            for (int i = num, j = sym; (i + 2 * skaX) >= 0 && (i + 2 * skaX) < 8  && 
                                       (j + 2 * skaY) >= 0 && (j + 2 * skaY)< 8 && 
                                       (mainMatrix[i +  skaX, j + skaY] != playerColor) &&
                                       (mainMatrix[i +  skaX, j + skaY] != 0);)
            {
                j += skaY;
                i += skaX;
                if (mainMatrix[i + skaX, j + skaY] == playerColor)
                {
                    turn[i - skaX, j - skaY] = true;
                }
            }
        }
	}

    /// <summary>
    /// converts direction to sutable for logic functions view
    /// Avilable axes are 'x' and 'y'
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="axis"></param>
    int directionToCoordinate(Direction direction, char axis)
    {
        if (axis == 'x')
        {
            if ((int) direction % 4 == 0) return 0;
            else if ((int) direction < 4) return 1;
            else return -1;
        }
        else if (axis == 'y')
        {
            if ((int) direction % 4 == 2) return 0;
            else if ((int) direction % 6 < 2) return 1;
            else return -1;
        }
        else throw new ArgumentOutOfRangeException();
    }
    

}
