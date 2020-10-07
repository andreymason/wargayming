using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject PvP;
    public GameObject PvE;
    public GameObject Canvas;
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

        Canvas.SetActive(false);

        Anim.Play("New Animation");
        //Invoke("Game", time);
    }

    private void Game()
    {
        if (x == 1)
        {
            //Тут будет логика ПвП
        }
        else
        {
            //Тут будет логика ПвЕ
        }
    }
}
