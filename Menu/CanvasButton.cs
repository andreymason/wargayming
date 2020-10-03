using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject PvP;
    public GameObject PvE;
    public GameObject Start;
    public GameObject Exit;
    public GameObject PvPButton;
    public GameObject PvEButton;
    public int _sceneNumber2;
    public int _sceneNumber;
    public Animation Anim;
    public float time;
    private int x;

    public void RestartGame()
    {
        if (PvP.activeSelf)
        {
            x = 1;
            //_sceneNumber = scene "gay"
            //What should be done when choosing pvp
        }
        else
        {
            x = 0;
            //_sceneNumber2 = another random scene 
            //What should be done when choosing pve
        }

        PvP.SetActive(false);
        PvE.SetActive(false);
        Start.SetActive(false);
        Exit.SetActive(false);
        PvPButton.SetActive(false);
        PvEButton.SetActive(false);
        
        Anim.Play("New Animation");
        Invoke("Game", time);
    }

    private void Game()
    {
        if (x == 1)
        {
            SceneManager.LoadScene(_sceneNumber);
        }
        else
        {
            SceneManager.LoadScene(_sceneNumber2);
        }
    }
}
