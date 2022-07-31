using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Vector3 offset ;
    public Transform Player ;
    // Start is called before the first frame update
    void Start()
    {
        offset =  transform.position - Player.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 pos = new Vector3 (transform.position.x , transform.position.y , Player.transform.position.z + offset.z ) ;
        transform.position  = pos ;
    }
}
