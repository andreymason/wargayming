using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDetection : MonoBehaviour{
    
    RaycastHit touch;
    float offsetX = 2.5f;
    float offsetZ = 2.5f;
    const float squareLength = 0.625f;
    int row;
    int column;
    int rayLength = 50;

    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 coords = new Vector3(touch.point.x + offsetX, 0, touch.point.z + offsetZ);
        if(Physics.Raycast(ray, out touch, LayerMask.GetMask("Board"))){
            Debug.DrawRay(ray.origin, ray.direction * rayLength, UnityEngine.Color.green);
            row    = (int)Mathf.Ceil(coords.x/squareLength);
            column = (int)Mathf.Ceil(coords.z/squareLength);
        }
        else{
            Debug.DrawRay(ray.origin, ray.direction * rayLength, UnityEngine.Color.red);
            row    = -1;
            column = -1;     
        }
        print(row + " " + column);
    }
}
