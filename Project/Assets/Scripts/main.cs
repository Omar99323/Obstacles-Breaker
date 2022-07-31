using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void play ()
    {
        SceneManager.LoadScene("ER");
    }

    public void Quitgame()
    {
        Application.Quit();
    }

}
