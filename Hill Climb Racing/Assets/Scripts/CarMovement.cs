using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private AudioSource _carAudioSource; // Referencia al AudioSource
    [SerializeField] private float _maxVolume = 0.5f; // Volumen m�ximo del sonido
    [SerializeField] private float _minVolume = 0.2f; // Volumen m�nimo del sonido
    [SerializeField] private float _volumeMultiplier = 0.5f; // Multiplicador de volumen basado en la velocidad


    private float _moveInput = 0f;

    private void Update()
    {
    //#if UNITY_EDITOR || UNITY_STANDALONE
        // Detecta las teclas de flecha derecha, flecha izquierda, a y d en el teclado para PC
        _moveInput = Input.GetAxisRaw("Horizontal");
//#elif UNITY_ANDROID || UNITY_IOS
    // se supone que deberia meterlo para android
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        float middleOfScreen = Screen.width / 2f;
        if (touch.position.x < middleOfScreen)
        {
            _moveInput = -1f; // Mover hacia atrás si toca el lado izquierdo de la pantalla
        }
        else
        {
            _moveInput = 1f; // Mover hacia adelante si toca el lado derecho de la pantalla
        }
    }
    else
    {
        _moveInput = 0f; // Si no hay toque, no mover
    }
//#endif
    }


    private void FixedUpdate()
    {
        //movement for the tires and the car in the air
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
        // Obtener la velocidad actual del coche
        float carSpeed = _carRB.velocity.magnitude;

        // Ajustar el volumen del sonido basado en la velocidad del coche
        float targetVolume = Mathf.Lerp(_minVolume, _maxVolume, carSpeed * _volumeMultiplier);
        _carAudioSource.volume = targetVolume;

        // Aplicar fuerzas de movimiento y rotaci�n
        float moveInput = Input.GetAxisRaw("Horizontal");
        _frontTireRB.AddTorque(-moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(moveInput * _rotationSpeed * Time.fixedDeltaTime);

        // Reproducir sonido si el coche se est� moviendo
        if (carSpeed > 0 && !_carAudioSource.isPlaying)
        {
            _carAudioSource.Play();
        }
    }
}
