using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrlToDemo : MonoBehaviour
{
    private float _horizontal, _vertical;
    private Transform _transform;
    
    public float moveSpeed = 10.0f;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        Vector3 moveDir = (Vector3.right * _horizontal) + (Vector3.up * _vertical);

        _transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }
}