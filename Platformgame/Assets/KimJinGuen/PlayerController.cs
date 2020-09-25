using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //public 변수 
    public float jumpForceMax = 5f;
    public Sprite gotJumpBarSprite;
    public float jumpChargeSpeed = 0.03f;
    public float xMoveSpeed = 0.05f;
    
    //private 변수
    private Rigidbody2D _rigidbody2D;
    private Collider2D _col;
    private GameObject _jumpBar;
    private SpriteRenderer _jumpBarSprite;
    private float _jumpbarLength;
    private float _horizontal;
    private float _jumpForce;
    private Vector2 _moveControl;
    private bool _isJumpCharge = false;
    private bool _canJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        
        //JumpBar 초기 설정
        _jumpBar = new GameObject();
        _jumpBar.name = "Player JumpBar";
        _jumpBar.AddComponent<SpriteRenderer>();
        _jumpBarSprite = _jumpBar.GetComponent<SpriteRenderer>();
        _jumpBarSprite.sprite = gotJumpBarSprite;
        _jumpBarSprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        _moveControl = _rigidbody2D.velocity;
        _horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyUp(KeyCode.Space) && _canJump) //스페이스바 떼기
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(1 * _horizontal, 2) * _jumpForce, ForceMode2D.Impulse);
            _jumpForce = 0;
            _isJumpCharge = false;
        }
        if (Input.GetKey(KeyCode.Space) && _canJump) //스페이스바 누르고 있을때
        {
            _isJumpCharge = true;
            _rigidbody2D.velocity = Vector2.zero;
            if (_jumpForce <= jumpForceMax)
            {
                _jumpForce += jumpChargeSpeed;
            }
        }
        //점프 바 설정
        SetJumpBar(_jumpBar, _jumpBarSprite);
        
        //캐릭터 움직임
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !_isJumpCharge && _canJump)
        {
            transform.position = new Vector3(transform.position.x + xMoveSpeed * _horizontal, transform.position.y, transform.position.z);
        }
        
        
        if (_isJumpCharge)
        {
            Vector2 v = _rigidbody2D.velocity;
            v.x = 0f;
            _rigidbody2D.velocity = v;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _canJump = false;
        }
    }

    private void SetJumpBar(GameObject jumpbar, SpriteRenderer jumpbarsprite)
    {
        _jumpbarLength = _jumpForce / jumpForceMax; //백분율
        jumpbar.transform.position = _col.transform.position + new Vector3(1, 1, 0);
        jumpbar.transform.localScale = new Vector3(2, _jumpbarLength * 10, 0);
        jumpbarsprite.color = new Color(1, 1 - _jumpbarLength, 1 - _jumpbarLength, 1);
    }
}
