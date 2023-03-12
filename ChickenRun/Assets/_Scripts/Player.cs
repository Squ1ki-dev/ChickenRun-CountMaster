using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public partial class Player : MonoBehaviour
{
    private int _numOfChicken;

    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _chickenPrefab;

    [SerializeField] private TextMeshPro _counterText;

    [Range(0f, 1f)] [SerializeField] private float _distance, _radius;

    [SerializeField] private bool _moveByTouch,
                _gameState;
    private Vector3 _mouseStartPos,
                    _playerStartPos;

    [SerializeField] private float _sensitive, _movementSpeed;
                                    
    
    private Camera _camera;
    
    private void Start()
    {
        _player = transform;
        _numOfChicken = transform.childCount - 1;
        _counterText.text = _numOfChicken.ToString();
        _camera = Camera.main;
    }
}
