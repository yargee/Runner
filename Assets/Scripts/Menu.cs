using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
