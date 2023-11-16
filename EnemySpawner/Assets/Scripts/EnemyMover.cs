using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector2 _direction;
    private int _xDirection = 0;
    private int _yDirection = 1;
    
    private void Awake()
    {
        _direction = new Vector2(_xDirection, _yDirection);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
