using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
    }
}
