using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PressedGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PressedExit()
    {
        Application.Quit();
    }

    public void PressedMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}