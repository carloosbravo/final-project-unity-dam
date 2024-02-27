using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput = 0f;

    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Detects the keyboard for pc
        _moveInput = Input.GetAxisRaw("Horizontal");
#elif UNITY_ANDROID
        // Detectar entrada de pantalla táctil 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middleOfScreen = Screen.width / 2f;
            if (touch.position.x < middleOfScreen)
                _moveInput = -1f; // Mover a la izquierda
            else
                _moveInput = 1f; // Mover a la derecha
        }
        else
        {
            _moveInput = 0f; // Si no hay toque, no mover
        }
#endif
    }

    private void FixedUpdate()
    {
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}
