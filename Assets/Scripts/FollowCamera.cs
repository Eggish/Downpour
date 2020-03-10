using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;
    //[SerializeField] private float LerpVelocity = 10.0f;
    [SerializeField] private Vector3 Offset = new Vector3(2.0f, 0, -10);

    
    //private Vector3 LastVelocity = Vector3.zero;

    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }

    }

    void FixedUpdate()
    {
        if (Player == null)
            return;
        Vector3 targetPos = Player.transform.position + Offset;
        targetPos.y = transform.position.y;

        //Vector3 lastPos = transform.position;

        //transform.position = Vector3.Lerp(transform.position, targetPos, LerpVelocity * Time.deltaTime);
        transform.position = targetPos;

        //transform.position =
        //    Vector3.SmoothDamp(transform.position, targetPos, ref LastVelocity, LerpVelocity * Time.deltaTime);
        //LastVelocity = lastPos - transform.position;
    }
}
