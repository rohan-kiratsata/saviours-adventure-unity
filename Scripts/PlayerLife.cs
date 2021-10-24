using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D playerRigidbody;
    private Rigidbody2D player;

    [SerializeField] private AudioSource dieSound;
    [SerializeField] private AudioSource bgSound;
    //[SerializeField] private Text lifeCounterText;

    
    
    private void Start()
    {
        // Get Component
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();

        // PlayerPrefs
        //savedLives.text = PlayerPrefs.GetInt("LiveRemainingVar", 0).ToString();
    }
    private void Update()
    {
        
    }

    // Method when Player collides with the traps
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            Die();
        }
    }
    // Player Die Script
    public void Die()
    {
        dieSound.Play();
        bgSound.Stop();

        anim.SetTrigger("playerDeath");
        playerRigidbody.bodyType = RigidbodyType2D.Static;
    }

    // Restarts Level when player dies.
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}