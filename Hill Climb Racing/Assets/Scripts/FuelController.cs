using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{

    //interface elements (you can modify the serialize ones in the interfaze)
    public static FuelController instance;

    [SerializeField] private Image _fuelImage;

    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;

    private float _currentFuelAmount;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    //when the game starts, the fuel bar is filled up with the max amount
    private void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();

    }

    //fuel level is reduce as time passes
    private void Update()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();

        if(_currentFuelAmount <= 0f)
        {
            GameManager.Instance.GameOver(); 

        }
    }

    //updates the interfaze level of gas and the color with the gradle we included in the interfaze

    private void UpdateUI()
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maxFuelAmount);

        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }

    //whenever it touches a can of fuell it will fill up the level of gas
    public void FillFuel() 
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }
}
