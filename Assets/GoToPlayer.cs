using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;
    [SerializeField] private float MovementSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = (Player.transform.position - transform.position).normalized;
        transform.position += directionToPlayer * MovementSpeed * Time.deltaTime;
    }
}
