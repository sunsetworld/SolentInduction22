using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public BoxCollider col;
    public float fieldOfView;
    public float zoomSpeed;
    private bool zooming = false;
    private float t;
    public GameObject load;
    public GameObject unload;


    private void Update()
    {
        if (zooming)
        {
            vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, fieldOfView, t);

            t += zoomSpeed * Time.deltaTime;

            if (t > 1f)
            {
                t = 0;
                zooming = false;
                col.enabled = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zooming = true;
            t = 0;
            col.enabled = false;
            if (load != null)
                load.SetActive(true);
            if (unload != null)
                unload.SetActive(false);
        }
    }
}
