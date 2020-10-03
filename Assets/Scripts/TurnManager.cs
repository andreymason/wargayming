using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{

    bool whiteTurn;
    ModelMatrix modMatObj = new ModelMatrix();
    ChipSpawner CPObj;

    void Start(){
        EventManager.AddSquarePressedListener(Turn);
        CPObj = GameObject.FindObjectOfType<ChipSpawner>();
    }

//use SpawnAndAddInMatrix depending on which turn
    private void Turn(Alpha sym, int num){
        if(ModelMatrix.mainMatrix[num - 1, (int)sym] != 0)
            return;
        if(whiteTurn){
            SpawnAndAddInMatrix(sym, num, Color.White);
        }
        else{
            SpawnAndAddInMatrix(sym, num, Color.Black);
        }
        whiteTurn = !whiteTurn;
    }

//spawns chip and add it to the mainMatrix
    private void SpawnAndAddInMatrix(Alpha sym, int num, Color color){
        modMatObj.AddValueToMainMatrix(sym, num, color);
        CPObj.SpawnChip(sym, num, color);
    }





}
