using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer();     
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        transform.position = player.position + offset;
    }
}
