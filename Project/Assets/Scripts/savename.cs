using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class savename : MonoBehaviour
{
    public InputField namefield ;
    public void saveclick()
    {
        PlayerPrefs.SetString("Name" , namefield.text );
    }

}
