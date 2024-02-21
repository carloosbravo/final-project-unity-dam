using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)

    {
        // we give to the whole car the tag 'player' so when it touches the can of gas the methos fillfuel is called.
        if(col.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel();
            Destroy(gameObject);
        }
    }

    
}
