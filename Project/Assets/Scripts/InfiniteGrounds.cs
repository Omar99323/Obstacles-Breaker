using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGrounds : MonoBehaviour
{
    public GameObject[] grounds ;
    List<GameObject> shownground = new List<GameObject>() ;
    private float groundpos = 0 ;
    private float groundlength = 30 ;
    public int numberofgrounds = 2 ;
    public Transform p ;
    void Start()
    {
        spawnground(0);
       for (int i = 0 ; i < numberofgrounds ; i++ )
       {
           spawnground(Random.Range(1, grounds.Length ));
       }
    }


    void Update()
    {
        if(p.transform.position.z > groundpos - (numberofgrounds * groundlength))
        {
           spawnground(Random.Range(1, grounds.Length ));
           deleteground();
        }
    }

    public void spawnground(int groundnum)
    {   
        GameObject G = Instantiate( grounds[groundnum] , transform.forward * groundpos , transform.rotation );
        shownground.Add(G);
        groundpos += groundlength ;
    }

    private void deleteground()
    {
        Destroy ( shownground[0] );
        shownground.RemoveAt(0);
    }

}

