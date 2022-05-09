using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RespawnButton()
    {
        SceneManager.LoadScene("AITest"); // Current game screen
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen"); // Main Menu
    }
}
