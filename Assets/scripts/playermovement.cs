using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // datatype variables...
    // other data type are similar like c++ but floating point number should end with f
    //ex float deci = 3.44f;
    private Rigidbody2D rb; // global variable
    // Start is called before the first frame update
    private Animator anime;
    private float dirx = 0f;
    // note in place of serailized we can make the variable public and they still be visible in unity but
    //that makes the var public and 
    [SerializeField]private float runspeed = 7f; // seralized field makes these vairables to be used directly in unity
    [SerializeField]private float jumpforce = 7f;
    private SpriteRenderer sprite;
    //private Transform transfrom;
    //private float directionx = 0f;

 // creating our won datatype

    private enum Movestate {idle,running,jumping,falling }
    //private Movestate movestate = Movestate.idle;

    private BoxCollider2D colide;

    [SerializeField] private LayerMask jumpableground;


    [SerializeField] private AudioSource jumpsoundeffect;



    private void Start()
    {
        // for c# this is the print statement.
        //Debug.Log("hello world");
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        colide = GetComponent<BoxCollider2D>();
       
    }

    // Update is called once per frame
    private void Update()
    {
        // getting the direcion x axis
        //float dirx = Input.GetAxis("Horizontal"); // in this case the player will slide a little bit which happends due to physics
         dirx = Input.GetAxisRaw("Horizontal"); // in case of raw it will stop immediately after the key press
        //moving in x direction

        rb.velocity = new Vector2(dirx * runspeed,rb.velocity.y); // here giving y value as the current value becuase if we move in xdir as well as jump than to work simultan.

        //directionx = transfrom.position.x;

        // jump
        //Debug.Log("i am updating!!");
        if (Input.GetButtonDown("Jump") && Isgrounded()) // more suitable
        {
            jumpsoundeffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce); // for 2d game

        }
        //if (Input.GetKeyDown("space"))
        //{
        //   rb.velocity = new Vector3(0, 7, 0);

        // }

        Updateanimation();
    
    }
    // self functon not default.
    private void Updateanimation()
    {
        Movestate state;
        // you can use anything for getting the position dirx or rb.velocity.x
        if (dirx > 0f)
        {
            state = Movestate.running;
            //anime.SetBool("running", true);
            sprite.flipX = false;


        }
        else if (dirx < 0f) // for  left
        {
            //anime.SetBool("running", true);
            sprite.flipX = true;
            state = Movestate.running;
        }
        else
        {
            state=Movestate.idle;
            //anime.SetBool("running", false);
        }
        if(rb.velocity.y > .1f)
        {
            state = Movestate.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = Movestate.falling;
        }

        anime.SetInteger("state",(int)state);
    }

    private bool Isgrounded()
    {
        // basically we are making another collider like we have made for the player and this time the detection is only downwards
       return Physics2D.BoxCast(colide.bounds.center, colide.bounds.size, 0f, Vector2.down, .1f,jumpableground);
    }

}
