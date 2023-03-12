using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Player
{
    private void FormatChicken()
    {
        for (int i = 0; i < _player.childCount; i++)
        {
            var x = _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var z = _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);
            var newPos = new Vector3(x, 0.524f, z);
            _player.transform.GetChild(i).DOLocalMove(newPos, 0.5f).SetEase(Ease.OutBack);
        }
    }

    private void CreateChickens(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_chickenPrefab, transform.position, Quaternion.identity, transform);
        }
        _numOfChicken = transform.childCount - 1;
        _counterText.text = _numOfChicken.ToString();
        FormatChicken();
    }

    private void OnTriggerEnter(Collider other) 
    {
        GateSystem gate = other.GetComponent<GateSystem>();
        if(gate)
        {
            gate.transform.GetComponent<BoxCollider>().enabled = false;
            if(gate._multiply)
                CreateChickens(_numOfChicken * gate._randomNumber);
            else
                CreateChickens(_numOfChicken + gate._randomNumber);
        }  
    }
}
