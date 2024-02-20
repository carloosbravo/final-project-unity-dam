using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)

    {
        // we give to the whole car the tag 'player' so when it touches the can of gas the methos fillfuel is called.
        if(collision.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel();
            Destroy(gameObject);
        }
    }
}
