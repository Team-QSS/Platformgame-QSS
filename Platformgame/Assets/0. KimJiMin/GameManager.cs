using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

// written by Kim Jimin
public class GameManager : MonoBehaviour
{
    private float _distance;
    private Vector3 _randomXVector3; 
    private float prevX; //이전 x값을 저장하는 변수
    private float intervalY;//Y 간격
    
    [FormerlySerializedAs("_Scaffolding")] public GameObject scaffolding; //발판 오브젝트
    public float intervalX; //이전 발판의 x값과 현재 발판의 x값 사이의 최소 거리

    void Start()
    {
        _randomXVector3 = new Vector3(Random.Range(-6, 6), 3, 0);
        Instantiate(scaffolding, _randomXVector3, Quaternion.identity);
        prevX = _randomXVector3.x;
        intervalY = Random.Range(3, 6);
    }

    void Update()
    {
        if (transform.position.y > _distance)
        {
            _distance += intervalY;
            SpawnScaffolding();
        }
    }

    //발판 생성 함수
    void SpawnScaffolding()
    {
        _randomXVector3.y += intervalY;
        _randomXVector3.x = Random.Range(-6, 6);
        while (!(prevX <= _randomXVector3.x - intervalX || prevX >= _randomXVector3.x + intervalX))
        {
            _randomXVector3.x = Random.Range(-6, 6);
        }
        Instantiate(scaffolding, _randomXVector3, Quaternion.identity);
        intervalY = Random.Range(3, 6);
        prevX = _randomXVector3.x;
    }
}