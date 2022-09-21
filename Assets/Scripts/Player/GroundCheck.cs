using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool grounded;

    private Vector2 normal;
    private PhysicMaterial material;

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }


    private void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            normal = collision.GetContact(i).normal;
            grounded |= normal.y >= 0.9f;
        }
    }
}
