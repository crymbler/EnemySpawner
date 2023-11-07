using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _timeToDestroy;

    private Transform[] _spawnpoints;
    private float _nextSpawnDelay;

    private void Start()
    {
        _spawnpoints = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _pointContainer.childCount; i++)
        {
            _spawnpoints[i] = _pointContainer.GetChild(i);
        }
    }

    private void Update()
    {
        if (Time.time > _nextSpawnDelay)
        {
            _nextSpawnDelay = Time.time + _spawnDelay;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int rundomNumber = Random.Range(0, _spawnpoints.Length);

        Vector2 spawnpoint = _spawnpoints[rundomNumber].position;
        Enemy enemy = Instantiate(_enemyPrefab, spawnpoint, Quaternion.identity);

        Destroy(enemy.gameObject, _timeToDestroy);
    }
}