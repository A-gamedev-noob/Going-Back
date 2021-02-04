using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagr : MonoBehaviour
{

    public Animator _Transition;

    public void PlayGame()
    {
        _Transition.SetTrigger("End");
        Invoke("PlayGameFun",1.2f);
    }
    void PlayGameFun()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        _Transition.SetTrigger("End");
        Invoke("RestartFun",1.2f);
    }
    void RestartFun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        _Transition.SetTrigger("End");
        Invoke("LoadNextLevelFun",1.2f);
    }
    void LoadNextLevelFun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
