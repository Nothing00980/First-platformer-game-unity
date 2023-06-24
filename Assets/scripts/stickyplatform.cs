using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyplatform : MonoBehaviour
{
    // moving player with the platform or on collision making player child of platform.
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
      

        
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{

       
    //}

    // the boxcollider that we made trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(transform);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
