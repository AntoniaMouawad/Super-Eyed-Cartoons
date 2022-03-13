using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 tempPos;
    [SerializeField] private float minX, maxX, minY, maxY;

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
        tempPos.y = player.transform.position.y - .5f;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        if (tempPos.y < minY)
            tempPos.y = minY;

        if (tempPos.y > maxY)
            tempPos.y = maxY;

        transform.position = tempPos;

    }
}
