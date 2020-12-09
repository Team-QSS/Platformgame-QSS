using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 조작 스크립트
// Main Camera에 넣음
public class CameraCtrl : MonoBehaviour
{
    private Transform _objectToFollowTransform;
    private float _followObjectY;

    public GameObject objectToFollow;
    public float moveSpeed = 3.0f;

    void Start()
    {
        _objectToFollowTransform = objectToFollow.GetComponent<Transform>();
    }

    void Update()
    {
        //지정한 오브젝트의 Y값을 따라가도록 함
        _followObjectY = _objectToFollowTransform.position.y;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _followObjectY,
            -10), moveSpeed * Time.deltaTime);

        if (objectToFollow == null)
        {
            Time.timeScale = 0;
        }
    }

    private void GameOver()
    {
        //게임 끝내기
    }
}
