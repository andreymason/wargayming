using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvP : MonoBehaviour
{
    public GameObject EllipsePvP;
    public GameObject EllipsePvE;

    public void Appear()
    {
        EllipsePvP.SetActive(false);
        EllipsePvE.SetActive(true);
    }
}
