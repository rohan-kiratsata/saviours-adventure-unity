using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectableStrawberry = 0;

    [SerializeField] private AudioSource eatSound;
    [SerializeField] private Text strawberryText;
    /*[SerializeField] private Text LifeCounterText;*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            eatSound.Play();
            Destroy(collision.gameObject);
            collectableStrawberry++;

            strawberryText.text = "" + collectableStrawberry;
        }
    }
}
