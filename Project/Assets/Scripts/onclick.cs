using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onclick : MonoBehaviour
{
    public void Replaygame()
    {
        SceneManager.LoadScene("ER");
    }

    public void Quitgame()
    {
        SceneManager.LoadScene("Main");
    }
}
