using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform transform;
    [SerializeField] Vector3 gap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void followPlayer()
    {
        cam.transform.position = transform.position;
    }
}
