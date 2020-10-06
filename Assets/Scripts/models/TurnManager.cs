using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{
    const Color userColor = Color.Black;
    Color color = Color.Black;
    ModelMatrix modMatObj;
    void Start(){
        EventManager.AddSquarePressedListener(Turn);
        modMatObj = gameObject.GetComponent<ModelMatrix>();
    }

    //use AddValueToMainMatrix depending on which turn
    public void Turn(Alpha sym, int num){
        if(color == userColor){
            if(modMatObj.AddValueToMainMatrix(sym, num, userColor)){
                color = (Color)(((int)color + 1)%2);
            }
        }
        if(color != userColor){
            AiTurn();
            color = (Color)(((int)color + 1)%2);
        }
    }
  
    private void AiTurn(){
        modMatObj.PossibleTurnsMatrix(color);
        List<int[]> posTurns = new List<int[]>();
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if(modMatObj.turn[i,j]){
                    int[] dot = new int[2];
                    dot[0] = i;
                    dot[1] = j;
                    posTurns.Add(dot);
                } 
            }
        }

        int[] randomMove = posTurns[Random.Range(0,posTurns.Count)];

        string debug = "AiTurn: " + (Alpha)randomMove[1] + " " + (randomMove[0]+1);
        modMatObj.AddValueToMainMatrix((Alpha)randomMove[1],randomMove[0] + 1, color);
    }
}

