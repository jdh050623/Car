using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFallow : MonoBehaviour
{
    public Transform TargetTransform;
    Vector2 refVelocity;

    public float smoothSpeed = 1.0f;
    public float gizmoSize = 2f;

    private void FixedUpdate()
    {
        if(TargetTransform != null)
        {
            transform.position = Vector2.SmoothDamp(transform.position, TargetTransform.position, ref refVelocity, smoothSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * gizmoSize);
    }
}
