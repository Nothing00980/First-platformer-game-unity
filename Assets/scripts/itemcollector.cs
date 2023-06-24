using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemcollector : MonoBehaviour
{
    private int melon = 0;
     public Text melontext ;
    [SerializeField] private AudioSource collectsoundeffect;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            collectsoundeffect.Play();
            Destroy(collision.gameObject);
            melon++;
            melontext.text = "melon: " + melon;
            //Debug.Log("melons:" + melon);
        }
    }


    // if we have not used is trigger then wehave to use the on collsion.
}
