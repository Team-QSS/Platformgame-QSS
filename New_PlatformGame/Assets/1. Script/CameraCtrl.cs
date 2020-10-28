using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Yu Jeongmin
public class CameraCtrl : MonoBehaviour
{
    private Transform _transform;
    private Transform _objectToFollowTransform;
    private float _followObjectY;

    public GameObject objectToFollow;
    public float moveSpeed = 3.0f;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _objectToFollowTransform = objectToFollow.GetComponent<Transform>();
    }

    void Update()
    {
        //지정한 오브젝트의 Y값을 따라가도록 함
        _followObjectY = _objectToFollowTransform.position.y;
        _transform.position = Vector3.Lerp(_transform.position, new Vector3(_transform.position.x, _followObjectY,
            -10), moveSpeed * Time.deltaTime);

        if (objectToFollow == null)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //게임 끝내기
    }
}