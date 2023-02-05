using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioSource defeat;

    private void Start()
    {
        defeat = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            defeat.Play();
            collision.gameObject.GetComponent<AudioSource>().Stop();
            FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().LoseCall();
        }
    }
}
