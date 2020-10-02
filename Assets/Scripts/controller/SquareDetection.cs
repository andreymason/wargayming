using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquareDetection : MonoBehaviour{
    SquarePressedEvent squarePressedEvent = new SquarePressedEvent();
    RaycastHit touch;
    const float offsetX = 2.5f;
    const float offsetZ = 2.5f;
    const float squareLength = 0.625f;
    protected static int num;
    protected static int sym;

    private void Start()
    {
        EventManager.AddSquarePressedInvoker(this);
    }

    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out touch, LayerMask.GetMask("Board"))){
            Vector3 coords = new Vector3(touch.point.x + offsetX, 0, touch.point.z + offsetZ);
            num = (int)Mathf.Ceil(coords.x/squareLength);
            sym = (int)Mathf.Ceil(coords.z/squareLength);
        }
        else{
            num = -1;
            sym = -1;     
        }
    }
    
    private void OnMouseDown()
    {
        if(num != -1 && sym != -1){
            squarePressedEvent.Invoke((Alpha)(sym - 1),num);
        }
    }

    public void AddSquarePressedListener(UnityAction<Alpha,int> listener){
        squarePressedEvent.AddListener(listener);
    }
}
