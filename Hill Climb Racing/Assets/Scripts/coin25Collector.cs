using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coin25Collection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinCounterText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Convertir el valor del TextMeshProUGUI a un número entero
            int contadorCoin = int.Parse(_coinCounterText.text);

            // Sumarle 5 al valor actual
            contadorCoin += 25;

            // Actualizar el TextMeshProUGUI con el nuevo valor del contador
            _coinCounterText.text = contadorCoin.ToString();

            // Destruir la moneda
            Destroy(gameObject);
        }
    }
}
