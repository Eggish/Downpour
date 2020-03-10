using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAiming : MonoBehaviour
{
    [SerializeField] private float RayLength = 50.0f;

    [SerializeField] private LayerMask RayLayer;

    void Update()
    {
        float DistanceToCam = (transform.position - Camera.main.transform.position).z;

        Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceToCam));

        transform.rotation = Quaternion.LookRotation(Vector3.forward, MouseWorldPos - transform.position);
    }
}
