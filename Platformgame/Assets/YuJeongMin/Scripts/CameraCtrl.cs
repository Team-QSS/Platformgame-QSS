using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Transform _transform;
    public GameObject followObject;
    private Transform _followObjectTransform;
    private float _followObjectY;
    public float moveSpeed = 3.0f;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _followObjectTransform = followObject.GetComponent<Transform>();
    }

    void Update()
    {
        _followObjectY = _followObjectTransform.position.y;
        _transform.position = Vector3.Lerp(_transform.position, new Vector3(_transform.position.x,_followObjectY, -10),
            moveSpeed * Time.deltaTime);
    }
}
