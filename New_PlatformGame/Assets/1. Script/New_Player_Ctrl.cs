using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewPlayerCtrl : MonoBehaviour
{
    //public 변수
    public float jumpForceMax = 200f; //점프하는 힘의 최대치
    public Sprite gotJumpBarSprite; //점프바의 스프라이트를 받기위한 변수
    public float jumpChargeSpeed = 1f; //점프하는 힘을 더하는 속도
    public float jumpBarLength; //점프바의 길이
    public float xMoveSpeed = 5f; //움직임 속도
    public float xMoveSpeedFly = 1f; //공중에 떠있을때 움직임 속도
    public float jumpBarPositionX = 1f; //점프바의 위치 X (캐릭터 기준)
    public float jumpBarPositionY = 1f; //점프바의 위치 Y (캐릭터 기준)

    //private 변수
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private GameObject _jumpBar; //점프바 변수
    private SpriteRenderer _jumpBarSprite; //점프바의 스프라이트 렌더러
    private float _xMove;
    private Vector2 _getvel; //Move 함수에서 캐릭터의 속도를 받는 변수
    private float _jumpForce; //점프하는 힘 변수
    private bool _isCharge; //점프하는 힘을 모으고 있는걸 확인하는 변수
    private bool _canJump; //땅에 있을때만 true
    private float _direction; //점프한 방향
    private bool _isAddJumpForceReverse; //점프하는 힘을 모으는 방향이 역방향인지 확인하는 변수

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();

        //JumpBar 초기 설정
        _jumpBar = new GameObject("Player JumpBar");
        _jumpBar.AddComponent<SpriteRenderer>();
        _jumpBarSprite = _jumpBar.GetComponent<SpriteRenderer>();
        _jumpBarSprite.sprite = gotJumpBarSprite;
        _jumpBarSprite.color = Color.white;
        
        
        //변수 초기화
        _jumpForce = 0f;
    }

    void Update()
    {
        Move();
        if (_canJump)
        {
            Jump();
        }
        SetJumpBar(_jumpBar, _jumpBarSprite);
    }

    private void SetJumpBar(GameObject jumpBar, SpriteRenderer jumpBarSprite) //점프 바 설정
    {
        jumpBarLength = _jumpForce / jumpForceMax; //백분율
        jumpBar.transform.position = _collider2D.transform.position + new Vector3(jumpBarPositionX, jumpBarPositionY, 0);
        jumpBar.transform.localScale = new Vector3(2, jumpBarLength * 10, 0);
        jumpBarSprite.color = new Color(1, 1 - jumpBarLength, 1 - jumpBarLength, 1);
    }
    

//땅에서 벗어나면 점프할 수 없다
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Scaffolding"))
        {   
            _canJump = true;
        }
    }

    //땅에서 벗어났을때 변수 조정
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Scaffolding"))
        {
            _direction = Input.GetAxis("Horizontal");
            _canJump = false;
        }
    }


    private void Move() //움직임 관리
    {
        _xMove = Input.GetAxis("Horizontal");
        if (!_isCharge && _canJump) //점프 차징중이거나 하늘에 떠있었을때 if문 진입 못함
        {
            _getvel = _rigidbody2D.velocity;
            _getvel.x = _xMove * xMoveSpeed;
            _rigidbody2D.velocity = _getvel;
        }
        else if (!_canJump && (int)_xMove != (int)_direction) //차징중이 아닐때 하늘에 떠있을 때 && 누르는 방향이 점프한 방향과 반대 방향일때
        {
            _rigidbody2D.AddForce(new Vector2(_xMove * xMoveSpeedFly,0));
        }
    }

//점프 함수
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SetjumpForce();
            _direction = Input.GetAxis("Horizontal");
            _isCharge = true;
            _rigidbody2D.velocity = Vector2.zero;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(_direction * _jumpForce,  _jumpForce * 2));
            _jumpForce = 0f;
            Invoke("SetIsCharge", 0.2f);
            _canJump = false;
        }
    }

    private void SetIsCharge()
    {
        _isCharge = false;
    }

    //점프하는 힘을 설정한다
    private void SetjumpForce()
    {
        if (_jumpForce <= jumpForceMax && !_isAddJumpForceReverse) //점프하는 힘이 최대치 보다 작고 힘이 올라가는 방향이 정방향일때
        {
            _jumpForce += jumpChargeSpeed; //힘이 늘어남
        }
        else if (_isAddJumpForceReverse && _jumpForce >= 0 && _isAddJumpForceReverse) //점프하는 힘이 0보다 크고 힘이 차는 방향이 역방향일때
        {
            _jumpForce -= jumpChargeSpeed; //힘이 줄어듬
        }

        if (_jumpForce >= jumpForceMax) //점프하는 힘이 최대치보다 크거나 같으면
        {
            _isAddJumpForceReverse = true; //힘이 차는 방향은 역방향
        }
        else if (_jumpForce <= 0) //점프하는 힘이 0보다 작으면
        {
            _isAddJumpForceReverse = false; //힘이 차는 방향은 정방향
        }
    }
}
