using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealBar : MonoBehaviour
{
    [SerializeField] private InfoPlayer _player;
    [SerializeField] private GameObject _bar;
    [SerializeField] private GameObject _deadScreen;
    [SerializeField] private Image _healBar;

    float _timer = 0;
    float _timerEndValue = 10;
    bool _isImmunity = false;

    private void Start()
    {
        _healBar.fillAmount = 1f;
    }

    private void OnTriggerEnter2D(Collider2D colliderOfEnemy)
    {
        StartCoroutine(StartTimer());

        if (colliderOfEnemy.TryGetComponent<PigMovement>(out PigMovement enemy) && _isImmunity == false)
        {
            TakeDamage();
            _isImmunity = true;
        }
    }

    private void TakeDamage()
    {
        _healBar.fillAmount -= 0.5f;

        if (_healBar.fillAmount <= 0)
        {
            Dead();
        }
    }

    private IEnumerator StartTimer()
    {
        while (_timer < _timerEndValue)
        {
            _timer = _timer + Time.deltaTime;

            yield return null;
        }

        _isImmunity = false;
        _timer = 0;
    }

    private void Dead()
    {
        Time.timeScale = 0;
        _deadScreen.SetActive(true);
    }
}
