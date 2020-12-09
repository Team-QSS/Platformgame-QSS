using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 미사일 조작 스크립트
// Missile에 넣음
public class MissileCtrl : MonoBehaviour
{
    public float _bombSpeed; //미사일 속도
    public float MissileReferenceTime; //미사일 생성 주기
    public GameObject Missile; //미사일 프리팹
    
    private readonly Vector3 _direction = Vector3.down;

    //미사일 움직임
    private void FixedUpdate()
    {
        transform.Translate(_direction * (_bombSpeed * Time.deltaTime));
    }

    //미사일과 닿은 플레이어 사망
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            //Destroy(col.gameObject);
        }
    }
}