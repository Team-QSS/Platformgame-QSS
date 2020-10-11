using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Lim Yeonsang
public class MissileCtrl : MonoBehaviour
{
    private float _bombSpeed = 1.5f; //미사일 속도
    private readonly Vector3 _direction = Vector3.down;

    //미사일움직임
    private void FixedUpdate()
    {
        transform.Translate(_direction * (_bombSpeed * Time.deltaTime));
    }

    //미사일과 닿은 플레이어 사망
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
            Destroy(col.gameObject);
    }
}
