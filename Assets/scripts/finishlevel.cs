using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishlevel : MonoBehaviour
{
    private AudioSource finishsound;  
    private bool finished = false;
    // Start is called before the first frame update
    private void Start()
    {
        // here we dont need to serialaize it since we have only one sound there is no ambiguity.
        finishsound = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player" && !finished)
        {

            finishsound.Play();
            finished = true;
            Invoke("completelevel", 2f);
            //completelevel();

        }
    }
    private void completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


}
