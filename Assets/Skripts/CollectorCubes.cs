using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCubes : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Cube>(out Cube cube))
        {
            _wallet.PutCoins(cube.Cost);
            Destroy(cube.gameObject);
        }
    }
}
