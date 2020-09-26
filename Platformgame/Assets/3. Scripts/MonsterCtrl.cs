using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

// written by Lim Yeonsang
public class MonsterCtrl : MonoBehaviour
{
    private bool _canMove = true;
    private float _mobSpeed = 1.5f; //몬스터 속도
    private readonly Vector3 _direction = Vector3.up;

    IEnumerator MakeCanNotMove()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.5f);
        _canMove = true;
    }

    //위로 움직임
    void FixedUpdate()
    {
        if (_canMove)
        {
            transform.Translate(_direction * (_mobSpeed * Time.deltaTime));
        }
    }

    //플레이어, 발판과 닿을 경우 닿은 오브젝트 삭제, 장애물과 닿을 경우 몬스터가 잠깐 멈춤 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log($"player : {col.name}");
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Scaffolding"))
        {
            Debug.Log($"scaffolding : {col.name}");
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Bomb"))
        {
            Debug.Log($"bomb : {col.name}");
            StartCoroutine(MakeCanNotMove());
        }
    }
}