using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P : MonoBehaviour
{
    private CharacterController Con ;
    public Animator ani ;
    public Text Tcoins ;
    public Text Tscore ;
    private Vector3 direction ;
    public float speed = 10 ;
    private int scoretext ;
    private int lane = 1 ;
    private float lanedistance = 2.5f ;
    public float jumpforce = 5 ;
    private float gravity = -10 ;
    public float maxspeed = 100 ;
    public static int numofcoins = 0 ;

    void Start()
    {
        Con = GetComponent<CharacterController>() ;
        StartCoroutine("score");
        
    }

    private void  FixedUpdate() 
    {
        if (!manager.startgame)
        {
            return ;
        }
        Con.Move( direction * Time.fixedDeltaTime ) ;
    }

    private IEnumerator slide()
    {
        ani.SetBool( "slide" , true );
        Con.center = new Vector3 (0, -0.5f ,0);
        Con.height = 1 ;
        yield return new WaitForSeconds(1.3f);
        ani.SetBool( "slide" , false );
        Con.center = new Vector3 (0, 0 ,0);
        Con.height = 2 ;
    }
    private IEnumerator score()
    {
        for(int i = 0 ;; i += 1)
        {
            scoretext = i ;
            yield return new WaitForSeconds(0.0000001f);
        }
    }

    void Update()
    {
        if (!manager.startgame)
        {
            return ;
        }
        ani.SetBool( "start" , true );
        Tcoins.text = "Coins : " + numofcoins ;
        Tscore.text = "Score : " + scoretext  ;
        // moving forward
        if (speed < maxspeed)
            speed += 0.1f * Time.deltaTime ;
        
        direction.z = speed ;

        //jumping
        if (Con.isGrounded)
        {
            ani.SetBool("jump",false);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {          
                jump();
                ani.SetBool("jump",true);
            }
            
        }  
        else
        {                      
            direction.y += gravity * Time.deltaTime ;
        }
        
        //sliding
        if (Input.GetKeyDown(KeyCode.DownArrow))
            StartCoroutine("slide");

        

        // moving left and right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ( lane < 2 )
            lane ++ ;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ( lane > 0 )
            lane -- ;
        }

        Vector3 Pposition = transform.position.z * transform.forward + transform.position.y * transform.up ;
        
        if ( lane == 0 )
        {
            Pposition += lanedistance * Vector3.left ;
        }
        else if ( lane == 2)
        {
            Pposition += lanedistance * Vector3.right ;
        }

        if (transform.position == Pposition)
            return;
        Vector3 diff = Pposition - transform.position ;
        Vector3 movedirection = diff.normalized * 25 * Time.deltaTime ;
        if (movedirection.sqrMagnitude < diff.sqrMagnitude)
            Con.Move(movedirection);
        else
            Con.Move(diff);
   
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if ( hit.transform.tag == "obstacle" )
        {
            manager.gameover = true ;
            FindObjectOfType<audiomanager>().playsounds("Game Over");
        }
    }
           
    private void jump()
    {
        direction.y = jumpforce ;  
    }
}
