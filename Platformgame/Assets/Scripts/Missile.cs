using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float bombspeed = 1.5f; //미사일 속도
    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(0, -1, 0);
    }   
    //미사일움직임
    private void FixedUpdate()
    {
        transform.Translate(direction * (bombspeed * Time.deltaTime));
    }
    //미사일과 닿은 플레이어 사망
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
            Destroy(col.gameObject);
    }
}
