using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaDeMeta : MonoBehaviour
{
    public string tagObjetoJugador = "Player";  // Etiqueta del objeto del jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagObjetoJugador))
        {
            // El objeto del jugador ha cruzado la línea de meta
            Debug.Log("¡Jugador ha cruzado la línea de meta!");
        }
    }
}
