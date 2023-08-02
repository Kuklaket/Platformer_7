using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPlayer : MonoBehaviour
{
    private float _heal = 75f;
    private float _healMax = 100f;

    public float ReturnHealCount()
    {        
        return _heal;
    }

    public float ReturnMaxHeal()
    {
        return _healMax;
    }

    public void GetHealCount(float heal)
    {
        _heal = heal;
    }
}
