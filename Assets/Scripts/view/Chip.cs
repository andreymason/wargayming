using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    Color color = Color.White;

    public void Flip(){
        gameObject.transform.Rotate(180f,0f,0f,Space.Self);
        color = (Color)(((int)color + 1)%2);
    }
}
