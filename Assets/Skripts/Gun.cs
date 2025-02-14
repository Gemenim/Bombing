using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Pool<Bullet> _pool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _velocity;

    [SerializeField] private float _sensitivityHorizontal;
    [SerializeField] private float _sensitivityVertical;

    [SerializeField] private float _rateOfFire = 1.0f;
    [SerializeField] private float _startSpeedBullet = 1.0f;

    [SerializeField] private float _maxRotation;
    [SerializeField] private float _minRotation;

    private Transform _transform;

    private void OnValidate()
    {
        if (_rateOfFire <= 0)
            _rateOfFire = 1.0f;

        if (_startSpeedBullet <= 0)
            _startSpeedBullet = 1.0f;
    }

    private void Awake()
    {
        _transform = transform;
        _pool = new Pool<Bullet>(Preload, GetAction, ReturnAction);
    }

    public void Guidance(Vector2 direction)
    {
        _transform.LookAt(direction, Vector3.forward);
        CheckGuidanceBoundaries();
    }

    public void Shoot()
    {
        Bullet bullet = _pool.Get();
        bullet.transform.position = _spawnPoint.position;
        bullet.SetDirection(_transform.forward);
    }

    private void CheckGuidanceBoundaries()
    {
        if (_transform.rotation.eulerAngles.x > _maxRotation)
            _transform.rotation = Quaternion.Euler(_maxRotation, _transform.rotation.eulerAngles.y, _transform.rotation.eulerAngles.y);

        if (_transform.rotation.eulerAngles.x < _minRotation)
            _transform.rotation = Quaternion.Euler(_maxRotation, _transform.rotation.eulerAngles.y, _transform.rotation.eulerAngles.y);
    }
    private Bullet Preload()
    {
        Bullet bullet = Instantiate(_prefab);
        bullet.SetPool(_pool);
        bullet.SetVelocity(_velocity);

        return bullet;
    }

    private void ReturnAction(Bullet bullet)
    {
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.gameObject.SetActive(false);
    }

    private void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);
}
