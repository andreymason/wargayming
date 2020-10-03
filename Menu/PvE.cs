using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvE : MonoBehaviour
{
    public GameObject EllipsePvP;
    public GameObject EllipsePvE;

    public void Appear()
    {
        EllipsePvP.SetActive(true);
        EllipsePvE.SetActive(false);
    }
}
