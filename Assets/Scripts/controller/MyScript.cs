using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour {

    ChipSpawner spawner;

    void Start () {
		ChipSpawner spawner = GameObject.FindObjectOfType<ChipSpawner>();
        spawner.SpawnChip(Alpha.D, 5, Color.Black);
        spawner.SpawnChip(Alpha.E, 4, Color.Black);
        spawner.SpawnChip(Alpha.D, 4, Color.White);
        spawner.SpawnChip(Alpha.E, 5, Color.White);
    }

}