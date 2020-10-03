using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject Line;
    public GameObject Sound;

    public void MusicAppear()
    {
        if (Sound.activeSelf)
        {
            Line.SetActive(true);
            Sound.SetActive(false);
        }
        else
        {
            Line.SetActive(false);
            Sound.SetActive(true);
        }
    }
}
