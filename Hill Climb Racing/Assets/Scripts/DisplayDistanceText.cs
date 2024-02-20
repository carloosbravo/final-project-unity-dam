using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDistanceText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private Transform _playerTrans;

    private Vector2 _startPosiion;

    private void Start()
    {
        _startPosiion = _playerTrans.position;
    }

    private void Update()
    {
        Vector2 distance = (Vector2)_playerTrans.position - _startPosiion;
        distance.y = 0f;

        if (distance.x < 0)
        {
            distance.x = 0;
        }
        _distanceText.text = distance.x.ToString("F0") + "m";
    }
}
