using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public static bool gameover ;
    public GameObject panel ;
    public static bool startgame ;
    public Text starttext ;
    public Text namebox ;
    void Start()
    {
        gameover = false ;
        Time.timeScale = 1 ;
        startgame = false ;
        namebox.text = "Hi " + PlayerPrefs.GetString("Name") ;
    }

    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0 ;
            panel.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            startgame = true ;
            Destroy(starttext);
            Destroy(namebox);
        }
    }
}
