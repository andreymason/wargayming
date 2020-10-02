using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backlight : SquareDetection
{
    const float FieldSize = 0.625f;
    const float coordXOffset = -2.175f;
    const float coordYOffset = 0.15f;
    const float coordZOffset = -2.175f;

    bool isCreated;
    public GameObject backlightPrefab;
    GameObject backlight;
    int currentSquareSym;
    int currentSquareNum;
    

    void Update(){
        if(!isCreated && num > 0 && sym > 0){
            CreateBacklight(sym, num);
            isCreated = true;
            currentSquareSym = sym;
            currentSquareNum = num;
        }
        if(PositionChanged(sym,num)){
            Destroy(backlight);
            isCreated = false;
        }
    }

    //creates backlight in the mouse poiner position
    void CreateBacklight(int sym, int num){
        backlight = Instantiate<GameObject>(backlightPrefab);
        backlight.transform.position = new Vector3(
            coordXOffset + (float)(num - 1) * FieldSize,
            coordYOffset,
            coordZOffset + (float)(sym - 1) * FieldSize);
    }

    //returs true when square changes
    bool PositionChanged (int sym, int num){
        if(currentSquareSym != sym || currentSquareNum != num)
            return true;
        else
            return false; 
    }
}
