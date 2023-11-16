using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector2 _direction;

    private void Awake()
    {
        _direction = new Vector2(0, 1);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
