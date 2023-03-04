using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public GameObject LevelCompleteUI;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision. collider. tag == "LevelComplete")
        {
            Time.timeScale = 0f;
            LevelCompleteUI.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("The Game is Quiting");
        Application.Quit();
    }
}
