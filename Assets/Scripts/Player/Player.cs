using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CoinsCounter _coinsCounterPrefab;
    [SerializeField] private float _jumpSpase;
    [SerializeField] private float _distance;

    private CoinsCounter _coinsCounterObject;
    private int _speed = 3;
    private Rigidbody2D _rigidbody2D;
    private bool _isGround = true;
    private bool _isJump = false;
    private Vector2 _displacementVector;
    private Animator _animator;
    private bool _isFacingRight = true;
    private int _instantiatePositionX = -11;
    private int _instantiatePositionY = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _coinsCounterObject = Instantiate(_coinsCounterPrefab, new Vector2(_instantiatePositionX, _instantiatePositionY), Quaternion.identity);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
  
    private void Update()
    {
        _displacementVector = Vector2.zero;
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _distance, _groundMask);

        if (hit.collider != null)
        {
            _isGround = true;
            _isJump = false;
        }
        else
        {
            _isGround = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovementHorizontal(true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MovementHorizontal(false);
        }
        else 
        {
            _animator.SetBool(HashForTags.TagRun, false);
        }

        if (Input.GetKey(KeyCode.E) && _isGround)
        {
            _animator.SetBool(HashForTags.TagJump, true);
            _isJump = true;
            Jump();
        }
        else
        {
            _animator.SetBool(HashForTags.TagJump, false);
        }

        transform.Translate(_displacementVector);
    }

    public CoinsCounter GetCoinsCounter()
    { return _coinsCounterObject; }

    private void MovementHorizontal(bool isRight)
    {
        int movementDirection;

        if (isRight)
        {
            movementDirection = 1; 
        }
        else
        {
            movementDirection = -1;
        }

        _displacementVector.x = _speed * Time.deltaTime * movementDirection;

        if (_isFacingRight != isRight)
        {
            Flip();
        }

        _isFacingRight = isRight;

        if(_isJump == false)
        {
            _animator.SetBool(HashForTags.TagRun, true);
        }
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(0, _jumpSpase);
        _isGround = false;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
