using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    GameObject object_cube; 

    public float speed = 0.1f;
    
    void Start () {
        
    }
	
	void Update () {
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
    }
}
