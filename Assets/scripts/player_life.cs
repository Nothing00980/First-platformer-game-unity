using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for realoading the game after death.

public class player_life : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rid;
    [SerializeField] private AudioSource deisound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            deisound.Play();
            Die();
        }
    }

    private void Die()
    {
        rid.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");



    }

    private void restartlevel()
    {
// reloading the current level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
