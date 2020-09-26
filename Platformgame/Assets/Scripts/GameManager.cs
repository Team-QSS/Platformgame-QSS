using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// written by Kim Jimin
public class GameManager : MonoBehaviour
{
    private float _distance;
    private Vector3 _dirVec;

    [FormerlySerializedAs("_Scaffolding")] public GameObject scaffolding; //발판 오브젝트
    public float interval; //간격

    void Start()
    {
        _dirVec = new Vector3(Random.Range(-6.5f, 6.5f), 4.5f, 0);
    }

    void Update()
    {
        if (transform.position.y > _distance)
        {
            _distance += interval;
            SpawnScaffolding();
        }
    }

    //발판 생성 함수
    void SpawnScaffolding()
    {
        Instantiate(scaffolding, _dirVec, Quaternion.identity);
        _dirVec.y += interval;
        _dirVec.x = Random.Range(-6.5f, 6.5f);
    }
}
