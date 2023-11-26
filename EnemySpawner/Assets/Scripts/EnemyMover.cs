using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector2 _direction;

    private void Awake()
    {
        Spawner spawner = new Spawner();
        _direction = spawner.EnemyDirection();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}