using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

// written by Lim Yeonsang
public class MonsterCtrl : MonoBehaviour
{
    private bool _canMove = true;

    private float mobspeed = 1.5f; //몬스터 속도
    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(0, 1, 0);
    }

    IEnumerator CantMove()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.5f);
        _canMove = true;
    }

    //몬스터움직임
    void FixedUpdate()
    {
        if (_canMove)
            transform.Translate(direction * (mobspeed * Time.deltaTime));
    }

    //몬스터와 닿은 플레이어 사망  
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
            Destroy(col.gameObject);

        if (col.gameObject.tag.Equals("Scaffolding"))
            Destroy(col.gameObject);

        if (col.gameObject.tag.Equals("Bomb"))
            StartCoroutine(CantMove());
    }
}