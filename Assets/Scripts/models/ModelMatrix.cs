using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMatrix : MonoBehaviour{

    public static int [,] mainMatrix;
    
    void Start(){
        mainMatrix = new int [8,8];
        // foreach(int value in mainMatrix){
        //     print(value);
        // }
    }

    void Update (){
 
    }

// adds in mainMatrix -1 if color == Black
//                     1 if color == White
    public void AddValueToMainMatrix(Alpha sym, int num, Color color){
        if(color == Color.Black)
            mainMatrix[num - 1, (int)sym] = -1;
        else
            mainMatrix[num - 1, (int)sym] =  1;
    }
}
