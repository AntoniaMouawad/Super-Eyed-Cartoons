using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 tempPos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        tempPos = transform.position;
        tempPos.x = player.transform.position.x;
        tempPos.y = player.transform.position.y;
        transform.position = tempPos;

    }
}
