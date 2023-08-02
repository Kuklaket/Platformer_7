using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;

    public static Action OnTouched;
   
    private void OnTriggerEnter2D(Collider2D colliderOfPlayer)
    {
        if (colliderOfPlayer.TryGetComponent<Player>(out Player player))
        {
            if (_coinsCounter != null)
            {
                player.GetCoinsCounter().AddCoin();
            }
         
            OnTouched?.Invoke();
            Destroy(gameObject);
        }
    }
}
