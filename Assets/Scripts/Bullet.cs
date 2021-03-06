﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float FlightSpeed = 5.0f;
    [SerializeField] private float ReflectionRayDelay = 0.01f;

    [Header("Links")]
    [SerializeField] private SpriteRenderer SpriteRenderer = null;
    [SerializeField] private GameObject ExplosionParent = null;
    [SerializeField] private ParticleSystem BounceParticle = null;
    [SerializeField] private CircleCollider2D Collider = null;
    [SerializeField] private AudioSource BounceSource = null;
    [SerializeField] private AudioSource ExplosionSource = null;
    [SerializeField] private AudioClip BounceSound = null;
    [SerializeField] private AudioClip ExplosionSound = null;
    [SerializeField] private Rigidbody2D Rigidbody = null;

    private Vector3 ReflectedVector = Vector3.up;
    private Vector3 ReflectionPoint = Vector3.one;

    void Start()
    {
        if (SpriteRenderer == null)
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Debug.Log("Please link SpriteRenderer in the Bullet");
        }

        if (Collider == null)
        {
            Collider = GetComponent<CircleCollider2D>();
            Debug.Log("Please link Collider in the Bullet");
        }
    }

    void FixedUpdate()
    {
        transform.position += (transform.up * FlightSpeed * Time.deltaTime); 

        Debug.DrawLine(transform.position, ReflectionPoint, Color.magenta);
        Debug.DrawLine(ReflectionPoint, ReflectionPoint+(ReflectedVector*4.0f), Color.yellow);
    }

    public void Explode()
    {
        SpriteRenderer.enabled = false;
        ExplosionParent.SetActive(true);
        Rigidbody.velocity = Vector3.zero;
        ExplosionSource.PlayOneShot(ExplosionSound);
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D pCollider)
    {
        if (pCollider.CompareTag("ChunkBoundary"))
            return;
        if(pCollider.CompareTag("FollowPlatform"))
        {
            FollowPlatform platformScript = pCollider.GetComponent<FollowPlatform>();
            Rigidbody.velocity += new Vector2(platformScript.GetMovementSpeed(), 0);
            VerticalPlatformBounce();
        }
        else
        {
            Bounce();
        }
    }

    public void GetShot()
    {
        GetReflectionVector();
        ExplosionParent.SetActive(false);
    }

    private void Bounce()
    {
        BounceParticle.Play();
        transform.rotation = Quaternion.LookRotation(transform.forward, ReflectedVector);
        BounceSource.PlayOneShot(BounceSound);
        Invoke("GetReflectionVector", ReflectionRayDelay);
    }
    private void VerticalPlatformBounce()
    {
        BounceParticle.Play();
        ReflectedVector = Vector3.Reflect(transform.up, Vector3.right);
        transform.rotation = Quaternion.LookRotation(transform.forward, ReflectedVector);
        BounceSource.PlayOneShot(BounceSound);
        Invoke("GetReflectionVector", ReflectionRayDelay);
    }
    private void HorizontalPlatformBounce()
    {
        BounceParticle.Play();
        ReflectedVector = Vector3.Reflect(transform.up, Vector3.up);
        transform.rotation = Quaternion.LookRotation(transform.forward, ReflectedVector);
        BounceSource.PlayOneShot(BounceSound);
        Invoke("GetReflectionVector", ReflectionRayDelay);
    }

    private void GetReflectionVector()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Collider.radius * transform.up), transform.up);
        if (hit)
        {
            ReflectionPoint = hit.point;
            ReflectedVector = Vector3.Reflect(transform.up, hit.normal);
        }
    }

    private void OnEnable()
    {
        SpriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        SpriteRenderer.enabled = false;
    }
}
