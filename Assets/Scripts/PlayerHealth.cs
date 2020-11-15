using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] AudioClip enemyReachedBaseSFX;

    [SerializeField] int health = 10;
    [SerializeField] Text healthText;


    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(enemyReachedBaseSFX);
        health--;
        healthText.text = health.ToString();
    }

}
