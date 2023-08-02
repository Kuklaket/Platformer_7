using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    private int _speed = 2;
    private float _damage;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TriggerForFlipEnemy>(out TriggerForFlipEnemy trigger))
        {
            Flip();
        }
    }

    private void Flip()
    {
        int horizontalRotate = 180;

        transform.Rotate(0, horizontalRotate, 0);
    }
}

