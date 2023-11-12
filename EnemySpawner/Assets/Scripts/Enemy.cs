using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}