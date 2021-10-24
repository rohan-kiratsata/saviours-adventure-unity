using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private AudioSource completeLevelSound;
    private bool isCompleteLevel = false;

    private void Start()
    {
        completeLevelSound = GetComponent<AudioSource>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isCompleteLevel)
        {
            completeLevelSound.Play();
            isCompleteLevel = true;
            Invoke("CompleteLevel", 3f);
        }
       
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
