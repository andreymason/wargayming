using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject chipPrefab;

    const float FieldSize = 0.625f;
    const float coordXOffset = -2.175f;
    const float coordYOffset = 0.15f;
    const float coordZOffset = -2.175f;

    //Spawns Chip in the given coordinates and with given color
    public void SpawnChip(Alpha sym, int num, Color color){
        if(num <= 0 || num > 8 ) throw new System.Exception();

        GameObject chip = Instantiate<GameObject>(chipPrefab);
        chip.transform.position = new Vector3(
            coordXOffset + (float)(num - 1) * FieldSize,
            coordYOffset,
            coordZOffset + (float)sym * FieldSize
        );
        if(color == Color.Black) chip.GetComponent<Chip>().Flip();
    }
}
