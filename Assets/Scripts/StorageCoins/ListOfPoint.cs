using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfPoint : MonoBehaviour
{
    private List<PointSpawn> _pointsSpawns = new();
    
    private void Start()
    {
        FillList();
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        _pointsSpawns[GeneratePointNumber()].SpawnCoin();
    }

    private void OnEnable()
    {
        Coin.OnTouched += SpawnCoin;
    }

    private void OnDisable()
    {
        Coin.OnTouched -= SpawnCoin;
    }
   
    private void FillList()
    {
        foreach (Transform oneTransform in transform)
        {
            if (oneTransform.tag == HashForTags.TagPoint)
            {
                GameObject pointAsGameObject = oneTransform.gameObject;
                pointAsGameObject.TryGetComponent<PointSpawn>(out PointSpawn pointAsScript);
                _pointsSpawns.Add(pointAsScript);
            }            
        }
    }

    private int GeneratePointNumber()
    {
        int pointNumber = Random.Range(0, _pointsSpawns.Count);

        return pointNumber;
    }
}
