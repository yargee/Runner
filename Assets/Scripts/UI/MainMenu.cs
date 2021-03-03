using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string Game = "Game";

    public void StartGame()
    {
        SceneManager.LoadScene(Game);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
