using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro GateText;

    [HideInInspector] public int _randomNumber;
    
    [HideInInspector] public bool _multiply => Random.value > 0.5f;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if(_multiply)
        {
            _randomNumber = Random.Range(2, 3);
            GateText.text = "X" + _randomNumber;
        }
        else
        {
            _randomNumber = Random.Range(10, 100);

            if(_randomNumber % 2 != 0)
                _randomNumber++;

            GateText.text = _randomNumber.ToString();
        }
    }
}
