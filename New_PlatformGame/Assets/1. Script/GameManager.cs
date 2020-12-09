using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//
// Player에 넣음
public class GameManager : MonoBehaviour
{
    private const int _coinCost = 10 ; //코인 단위
    private int _getCoin; //플레이어가 얻은 코인
    private int _coin; //플레이어가 지니고 있는 총 코인


    private float _distance;
    private Vector3 _randomXVector3;
    private Vector3 CameraPositionTopRight; //카메라 위쪽의 Y좌표값을 가져오는 역할
    private Vector3 CameraPositionBottomLeft;
    private float prevX; //이전 x값을 저장하는 변수
    private float intervalY;//Y 간격
    private float _palyerStartY; //플레이어의 시작 Y값을 가져옴
    private int _maxScore; //최고점수
    public int _score;

    [FormerlySerializedAs("_Scaffolding")] public GameObject scaffolding; //발판 오브젝트
    public float intervalX; //이전 발판의 x값과 현재 발판의 x값 사이의 최소 거리

    public float MissileReferenceTime; //미사일 생성 주기
    public GameObject Missile; //미사일 프리팹
    public GameObject MissileSpawn;// 미사일 스폰 프리팹

    private Vector3 MissileRespawn;//미사일을 생성하는 곳의 좌표
    private float MissileTime;//미사일 생성 쿨타임

    private float _playerStartYPos;
    void Start()
    {
        CameraPositionTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0));
        CameraPositionBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0,0, 0));
        MissileRespawn = new Vector3(Random.Range(-6, 6), CameraPositionTopRight.y,0);
        _randomXVector3 = new Vector3(Random.Range(-6, 6), 3, 0);
        Instantiate(scaffolding, _randomXVector3, Quaternion.identity);
        prevX = _randomXVector3.x;
        intervalY = Random.Range(3, 6);
        MissileTime = 0;
        _palyerStartY = transform.position.y;
        _maxScore = PlayerPrefs.GetInt("Best Score", 0);
        _coin = PlayerPrefs.GetInt("Coin", 0);
        _getCoin = 0;
    }

    void Update()
    {
        if (transform.position.y > _distance)
        {
            _distance += intervalY;
            SpawnScaffolding();
        }

        if (_score < (int) transform.position.y)
        {
            _score = (int)transform.position.y;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (_maxScore < (int) (_score - _palyerStartY))
        {
            SaveScore();
        }
    }

    private void FixedUpdate()
    {
        MissileTime += Time.deltaTime;
        if (MissileTime > MissileReferenceTime)
        {
            CameraPositionTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            MissileRespawn = new Vector3(Random.Range(CameraPositionBottomLeft.x, CameraPositionTopRight.x), CameraPositionTopRight.y,0);
            Instantiate(MissileSpawn, MissileRespawn, Quaternion.identity);
            Invoke("MissileSummoning", 3);
            MissileTime = 0;
        }
    }

    //발판 생성 함수 -> 플레이
    void SpawnScaffolding()
    {
        _randomXVector3.y += intervalY;
        _randomXVector3.x = Random.Range(CameraPositionBottomLeft.x, CameraPositionTopRight.x);
        while (!(prevX <= _randomXVector3.x - intervalX || prevX >= _randomXVector3.x + intervalX) || (prevX - _randomXVector3.x >= 8 || _randomXVector3.x - prevX >= 8))
        {
            _randomXVector3.x = Random.Range(CameraPositionBottomLeft.x, CameraPositionTopRight.x);
        }
        Instantiate(scaffolding, _randomXVector3, Quaternion.identity);
        intervalY = Random.Range(3, 6);
        prevX = _randomXVector3.x;
    }

    //미사일 생성 -> 플레이
    void MissileSummoning()
    {
        CameraPositionTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Instantiate(Missile, new Vector3(MissileRespawn.x, CameraPositionTopRight.y, 0), Quaternion.identity);
    }

    // 점수 저장 -> 저장
    void SaveScore()
    {
        _maxScore = (int) (_score - _palyerStartY + 1);
        PlayerPrefs.SetInt("Best Score", _maxScore);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _getCoin += _coinCost;
            Destroy(other.gameObject);
        }
    }

    // 코인 저장 -> 저장
    private void SaveCoin()
    {
        _coin += _getCoin;
        PlayerPrefs.SetInt("Coin", _coin);
        Debug.Log(_coin);
    }
}
