using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Update()
    {
        MoveThePlayer();
    }

    private void MoveThePlayer()
    {
        if(Input.GetMouseButtonDown(0) && _gameState)
        {
            _moveByTouch = true;

            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if(plane.Raycast(ray, out var _distance))
            {
                _mouseStartPos = ray.GetPoint(_distance + 1f);
                _playerStartPos = transform.position;
            }
        }

        if(Input.GetMouseButtonUp(0))
            _moveByTouch = false;

        if(_moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if(plane.Raycast(ray, out var _distance))
            {
                var mousePos = ray.GetPoint(_distance + 1f);
                var move = mousePos - transform.position;
                var control = _playerStartPos + move;

                if(transform.childCount < 50)
                    control.x = Mathf.Clamp(control.x, -1f, 1f);
                else
                    control.x = Mathf.Clamp(control.x, -0.7f, 0.7f);

                transform.position = new Vector3(Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * _sensitive), transform.position.y, transform.position.z);
            }
        }

        if(_gameState)
            _player.Translate(-transform.forward * Time.deltaTime * _movementSpeed);
    }
}