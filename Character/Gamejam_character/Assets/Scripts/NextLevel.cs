using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private bool levelCompleted = false;
    private bool lvlCompleptedP1 = false; 
    private bool lvlCompleptedP2 = false;

    private AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "female_idle" && !lvlCompleptedP1)
        {
            lvlCompleptedP1 = true;
        }
        
        if (collision.gameObject.name == "player_idle" && !lvlCompleptedP2)
        {
            lvlCompleptedP2 = true;
        }

        if (lvlCompleptedP1 && lvlCompleptedP2)
        {
            levelCompleted = true;
            win.Play();
            Invoke("CompleteLevel", 2);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
