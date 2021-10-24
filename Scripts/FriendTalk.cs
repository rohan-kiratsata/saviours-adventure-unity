using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendTalk : MonoBehaviour
{
    [SerializeField] private Text myText;
    


    void Start()
    {
        myText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Friend Box Collidor")
        {
            myText.enabled = true;
        }
    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {
      
    }*/
}
