using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPartialRotation : MonoBehaviour {

    public Transform source;
    public float ratio;

    public Transform target;
    public float smooth = 0.3F;
    public float distance = 5.0F;
    private float yVelocity = 0.0F;

    float yRot;
    float zAngle;
    // Use this for initialization

    private void FixedUpdate()
    {
        CalculateSourceRotation();
    }

    private void CalculateSourceRotation()
    {
        zAngle = source.rotation.eulerAngles.z;
        zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;

        yRot = zAngle * ratio;
        DebugPanel.Log("zAngle", "yrot", zAngle);
        DebugPanel.Log("yrot", "yrot", yRot);

        transform.rotation = Quaternion.Euler(0, 0, yRot );    
    }

    private void SmoothDump()
    {
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
        Vector3 position = target.position;
        position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, 0, -distance);
        transform.position = position;
        transform.LookAt(target);
    }
}
