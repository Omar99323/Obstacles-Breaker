using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50*Time.deltaTime,0,0);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<audiomanager>().playsounds("Pick Ups");
            P.numofcoins += 1 ;
            Destroy (gameObject);
        }
    }
}
