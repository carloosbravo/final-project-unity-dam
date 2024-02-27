using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] private GameObject _winingCanvas;
    [SerializeField] private GameObject _interfaceCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player enters the finishing line it will active de canvas 
        if (collision.CompareTag("Meta")) 
        {
            // Show the canvas of winning
            _winingCanvas.SetActive(true);
            _interfaceCanvas.SetActive(false);
        }
    }
}
