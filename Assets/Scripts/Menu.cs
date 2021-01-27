using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
