using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private float _spawnDelay;

    private Transform[] _spawnPoints;
    private WaitForSeconds _delay;
    private Coroutine _spawnRoutine;
    private int _minXDirection = -5;
    private int _maxXDirection = 5;
    private int _minYDirection = -5;
    private int _maxYDirection = 5;

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);

        _spawnPoints = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _pointContainer.childCount; i++)
        {
            _spawnPoints[i] = _pointContainer.GetChild(i);
        }

        _spawnRoutine = StartCoroutine(SpawnEnemy());
    }

    private void OnDestroy()
    {
        StopCoroutine(_spawnRoutine);
    }

    public Vector2 DirectionGeneration()
    {
        return new Vector2(Random.Range(_minXDirection, _maxXDirection), Random.Range(_minYDirection, _maxYDirection));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int rundomNumber = Random.Range(0, _spawnPoints.Length);
            Vector2 spawnPoint = _spawnPoints[rundomNumber].position;

            EnemyMover enemy = Instantiate<EnemyMover>(_enemyPrefab, spawnPoint, Quaternion.identity);
            enemy.SetDirection(DirectionGeneration());

            yield return _delay;
        }
    }
}