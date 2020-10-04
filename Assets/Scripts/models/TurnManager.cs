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
            AiTurn(color);
            color = (Color)(((int)color + 1)%2);
        }
    }

    private void AiTurn(Color color){
        modMatObj.PossibleTurnsMatrix(color);
        List<int[]> posTurns = new List<int[]>();
        MatrixDebug();
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
        
        Debug.Log("AiTurn: " + (Alpha)randomMove[1] + " " + (randomMove[0]+1));
        modMatObj.AddValueToMainMatrix((Alpha)randomMove[1],randomMove[0] + 1, color);
    }  

    void MatrixDebug(){
        string a = "A          ";
        a += "B         ";
        a += "C         ";
        a += "D         ";
        a += "E         ";
        a += "F         ";
        a += "G         ";
        a += "H         \n";
        for(int i = 0; i < 8; i++){
            a += (i+1) + " ";
            for(int j = 0; j < 8; j++){
                a += (modMatObj.turn[i,j].ToString() + " ").PadRight(5,' ');
            }
            a += "\n";
        }
        Debug.Log(a); 
    }
}

