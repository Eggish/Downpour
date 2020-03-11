using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAiming : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        float distanceToCam = (transform.position - Camera.main.transform.position).z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCam));

        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseWorldPos - transform.position);
    }
}
