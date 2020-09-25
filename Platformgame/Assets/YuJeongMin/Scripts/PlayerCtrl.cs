using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float _h, _v;
    private Transform _tr;
    public float moveSpeed = 10.0f; 
    void Start()
    {
        _tr = GetComponent<Transform>();
    }

    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        Vector3 moveDir = (Vector3.right * _h) + (Vector3.up * _v);
        
        _tr.Translate(moveDir*moveSpeed*Time.deltaTime,Space.Self);
    }
}
