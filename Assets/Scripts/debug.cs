using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddSquarePressedListener(OnSquarePressed);
    }

    private void OnSquarePressed(Alpha sym ,int num){
        Debug.Log("sym = " + sym.ToString() + "\nnum = " + num.ToString());
    }
}
