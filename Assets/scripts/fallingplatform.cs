using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ch1, ch2;
    Transform current;
    public int spped = 5;
    [SerializeField] private BoxCollider2D bo;

    // Update is called once per frame

    private void Start()
    {
        current = ch2;
        bo = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.transform.SetParent(transform);

            if (Vector2.Distance(transform.position, ch1.transform.position) < .1f)
            {
                current = ch2;
            }

            else if (Vector2.Distance(transform.position, ch2.transform.position) < .1f)
            {
                current = ch1;
            }



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
  
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, current.transform.position, Time.deltaTime * spped);
        
    }



}
