using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject _Scaffolding;
    public float interval;
    
    private float distance;
    private Vector3 dirVec;
    // Start is called before the first frame update
    void Start()
    {
        dirVec = new Vector3(Random.Range(-6.5f, 6.5f), 4.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,1,0);
        }

        if (transform.position.y > distance)
        {
            distance += interval;
            SpawnScaffolding();
        }
    }
    
    void SpawnScaffolding()
    {
        Instantiate(_Scaffolding, dirVec, Quaternion.identity);
        dirVec.y += interval;
        dirVec.x = Random.Range(-6.5f, 6.5f);
    }
}
