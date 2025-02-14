using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public event Action<int> ChangeCount;

    public void PutCoins(int coins)
    {
        _coins += coins;
        ChangeCount?.Invoke(coins);
    }

    public bool GetCoins(int requiredCoins)
    {
        if (_coins > requiredCoins)
        {
            _coins -= requiredCoins;
            ChangeCount?.Invoke(_coins);
            return true;
        }

        return false;
    }
}
