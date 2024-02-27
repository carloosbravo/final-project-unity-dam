using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private AudioSource _carAudioSource; // Referencia al AudioSource
    [SerializeField] private float _maxVolume = 0.5f; // Volumen máximo del sonido
    [SerializeField] private float _minVolume = 0.2f; // Volumen mínimo del sonido
    [SerializeField] private float _volumeMultiplier = 0.5f; // Multiplicador de volumen basado en la velocidad

    private void FixedUpdate()
    {
        // Obtener la velocidad actual del coche
        float carSpeed = _carRB.velocity.magnitude;

        // Ajustar el volumen del sonido basado en la velocidad del coche
        float targetVolume = Mathf.Lerp(_minVolume, _maxVolume, carSpeed * _volumeMultiplier);
        _carAudioSource.volume = targetVolume;

        // Aplicar fuerzas de movimiento y rotación
        float moveInput = Input.GetAxisRaw("Horizontal");
        _frontTireRB.AddTorque(-moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(moveInput * _rotationSpeed * Time.fixedDeltaTime);

        // Reproducir sonido si el coche se está moviendo
        if (carSpeed > 0 && !_carAudioSource.isPlaying)
        {
            _carAudioSource.Play();
        }
    }
}
