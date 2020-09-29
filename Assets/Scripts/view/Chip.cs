using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    Color color = Color.White;
    Alpha sym;
    int num;

    public void Flip(){
        gameObject.transform.Rotate(180f,0f,0f,Space.Self);
        color = (Color)(((int)color + 1)%2);
    }

    public Color Color{
        get => color;
        set{
            if (value != color){
                this.Flip();
            }
        }
    }

    public Alpha Sym{
        get => sym; 
        set => sym = value;
    }

    public int Num{
        get => num;
        set{
            if (value <= 0 || value > 8){
                throw new System.ArgumentOutOfRangeException();
            }
            else num = value;
        }
    }
}
