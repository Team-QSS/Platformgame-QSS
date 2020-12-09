using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

// 몬스터 조작 스크립트
// Monster에 넣음
public class MonsterCtrl : MonoBehaviour
{
    public float _mobSpeed = 1.5f; //몬스터 속도
    private bool _canMove = true;
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

    //몬스터가 닿은 오브젝트
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log($"player : {col.name}");
            /*Destroy(col.gameObject);*/
            Time.timeScale = 0;
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
            Destroy(col.gameObject);
        }
    }
}
