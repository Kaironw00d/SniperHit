using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private int damage = 25;
    [SerializeField] private float speed = 2;
    public GameObjectPool Pool { get; set; }

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    public void Launch(Vector3 startPosition, Quaternion startRotation, Vector3 direction)
    {
        _transform.position = startPosition;
        _transform.rotation = startRotation;
        _direction = direction;
    }

    private void Update()
    {
        _rigidbody.velocity = _direction * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        var damageable = other.gameObject.GetComponent<ITakeDamage>();
        damageable?.TakeDamage(damage);
        Pool.ReturnToPool(gameObject);
    }
}