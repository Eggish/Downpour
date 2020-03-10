using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float FlightSpeed = 5.0f;

    [SerializeField] private Vector3 ReflectedVector = Vector3.up;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += (transform.right * FlightSpeed * Time.deltaTime); 
    }

    public void Explode()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D p_Collider)
    {
        if (p_Collider.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            //transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.Reflect(transform.up, p_Collider.GetContact(0).normal));
        }
    }

    public void GetShot()
    {

    }

    private void GetReflectionVector()
    {
        RaycastHit2D hit;
        //if(Physics.Raycast(transform.position, transform.right, out hit))
        //{
        //    ReflectedVector = 
        //}
    }
}
