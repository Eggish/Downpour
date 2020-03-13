using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlatform : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;

    private float MaximumXDistanceToPlayer = 0.0f;

    //[SerializeField] private float MovementSpeed = 3.0f; 
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }

        MaximumXDistanceToPlayer = Player.transform.position.x - transform.position.x;
    }

    void LateUpdate()
    {
        //transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        if (Player.transform.position.x - transform.position.x > MaximumXDistanceToPlayer)
        {
            transform.position = new Vector3(Player.transform.position.x - MaximumXDistanceToPlayer, transform.position.y, transform.position.z);
        }
    }
}
