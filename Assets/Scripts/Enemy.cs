using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float delta = 2;
    private float minX;


    private void Awake()
    {
        minX = transform.position.x;
    }

    void LateUpdate()
    { 
        transform.position = new Vector3(minX - Mathf.PingPong(Time.time, delta) , transform.position.y, transform.position.z);

    }
}

