using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
