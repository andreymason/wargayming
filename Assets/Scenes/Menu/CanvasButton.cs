using UnityEngine.SceneManagement;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public string sceneName;
     
    public void RestartGame(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
