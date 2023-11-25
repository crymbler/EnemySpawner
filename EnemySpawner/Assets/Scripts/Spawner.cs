using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay;

    private Transform[] _spawnpoints;
    private WaitForSeconds _delay;
    private int _minAngle;
    private int _maxAngle;

    private void Awake()
    {
        _minAngle = 0;
        _maxAngle = 360;

        _delay = new WaitForSeconds(_spawnDelay);
    }

    private void Start()
    {
        _spawnpoints = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _pointContainer.childCount; i++)
        {
            _spawnpoints[i] = _pointContainer.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int rundomNumber = Random.Range(0, _spawnpoints.Length);

            Vector2 spawnpoint = _spawnpoints[rundomNumber].position;
            Instantiate(_enemyPrefab, spawnpoint, Quaternion.Euler(new Vector3(Random.Range(_minAngle, _maxAngle), Random.Range(_minAngle, _maxAngle), 0)));

            yield return _delay;
        }
    }
}