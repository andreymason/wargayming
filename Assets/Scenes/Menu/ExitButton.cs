using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public string sceneName;

    public void ExitGame()
    {
        Application.Quit();
    }
}
