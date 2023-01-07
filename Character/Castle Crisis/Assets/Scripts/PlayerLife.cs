using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        death = GetComponent<AudioSource>();

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {

        death.Play();
        
        rb.bodyType = RigidbodyType2D.Static;
        Invoke("renderDisable", 1);
        sr.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("RestartLevel", 1);
        
        
    }
    private void renderDisable()
    {

        sr.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

