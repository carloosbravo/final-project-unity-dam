using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound1; // Primer sonido de la colisi�n
    [SerializeField] private AudioClip collisionSound2; // Segundo sonido de la colisi�n
    private AudioSource audioSource; // Referencia al AudioSource

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.GameOver();

            // Reproducir el primer sonido
            if (collisionSound1 != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound1);
            }

            // Reproducir el segundo sonido
            if (collisionSound2 != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound2);
            }
        }
    }
}

