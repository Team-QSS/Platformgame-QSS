using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawn : MonoBehaviour
{
    private Vector3 CameraPositionTopRight;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraPositionTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        this.transform.position = new Vector3(this.transform.position.x, CameraPositionTopRight.y, 0);
        Invoke("DestoryMissileSpawn", 3);
    }

    void DestoryMissileSpawn()
    {
        Destroy(this.gameObject);
    }
}
