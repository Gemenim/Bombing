using UnityEngine;

public class MoverCart : MonoBehaviour
{
    [SerializeField] private Transform _rails;

    private Transform _transform;
    private float _minBarrier;
    private float _maxBarrier;

    private void Awake()
    {
        _transform = transform;

        _minBarrier = _rails.localPosition.x - _rails.localScale.x / 2;
        _maxBarrier = _rails.localPosition.x + _rails.localScale.x / 2;
    }

    public void MoveCar()
    {
        float positionCar = Random.Range(_minBarrier, _maxBarrier);
        _transform.position = new Vector3(positionCar, _transform.position.y, _transform.position.z);
    }
}
