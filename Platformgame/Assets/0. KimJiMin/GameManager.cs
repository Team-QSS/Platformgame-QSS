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

    [FormerlySerializedAs("_Scaffolding")] public GameObject scaffolding; //발판 오브젝트
    public float interval = 5; //간격

    void Start()
    {
        _randomXVector3 = new Vector3(Random.Range(-6.5f, 6.5f), 4.5f, 0);
    }

    void Update()
    {
        if (transform.position.y > _distance)
        {
            _distance += interval;
            SpawnScaffolding();
        }
    }

    //발판 생성 함수
    void SpawnScaffolding()
    {
        Instantiate(scaffolding, _randomXVector3, Quaternion.identity);
        _randomXVector3.y += interval;
        _randomXVector3.x = Random.Range(-6.5f, 6.5f);
    }
}
