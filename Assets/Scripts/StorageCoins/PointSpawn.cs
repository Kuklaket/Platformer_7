using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    public void SpawnCoin()
    {
        Instantiate(_coin,transform.position , Quaternion.identity);
    }
}
