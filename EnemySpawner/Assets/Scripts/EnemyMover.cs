using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}