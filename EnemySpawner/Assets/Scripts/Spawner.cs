using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _speed;

    private Transform[] _spawnpoints;
    private WaitForSeconds _delay;
    private Enemy enemy;
    Vector2 _direction;
    private int _minXDirection = -5;
    private int _maxXDirection = 5;
    private int _minYDirection = -5;
    private int _maxYDirection = 5;

    private void Awake()
    {
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

    private void Update()
    {
        EnemyMover();
    }

    private void EnemyMover()
    {
        enemy.transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int rundomNumber = Random.Range(0, _spawnpoints.Length);
            Vector2 spawnpoint = _spawnpoints[rundomNumber].position;

            enemy = Instantiate(_enemyPrefab, spawnpoint, Quaternion.identity);

            _direction = new Vector2(Random.Range(_minXDirection, _maxXDirection), Random.Range(_minYDirection, _maxYDirection));

            yield return _delay;
        }
    }
}