using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject PvP;
    public GameObject PvE;
    public int _sceneNumber2;

    public void RestartGame(int _sceneNumber)
    {
        if (PvP.activeSelf)
        {
            SceneManager.LoadScene(_sceneNumber);
            //_sceneNumber = scene "gay"
            //What should be done when choosing pvp
        }
        else
        { 
            SceneManager.LoadScene(_sceneNumber2);
            //_sceneNumber2 = another random scene 
            //What should be done when choosing pve
        }
    }
}
