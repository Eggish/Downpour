using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody = null;
    [SerializeField] private GameObject Gun = null;
    [SerializeField] private Bullet Bullet = null;
    
    [SerializeField] private KeyCode ShootKey = KeyCode.Mouse0;

    [SerializeField] private float ShotRecoilForce = 50.0f;
    [SerializeField] private float ExplosionRecoilForce = 500.0f;
    [SerializeField] private float ExplosionDistanceDivisionMultiplier = 1.0f;

    [SerializeField] private float ShotCooldown = 0.5f;
    private float ShotTimer = 0.0f;

    void Start()
    {
        Bullet.enabled = false;
    }

    void Update()
    {
        ShotTimer -= Time.deltaTime;

        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(ShootKey))
        {
            if (Bullet.enabled)
            {
                Bullet.Explode();
                ExplosionRecoil();;
            }
            else if(ShotTimer <= 0)
            {
                
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D p_Collision)
    {
        if (p_Collision.CompareTag("Dangerous"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ExplosionRecoil()
    {
        Vector3 explosionDirection = (transform.position - Bullet.transform.position).normalized;
        float distanceToExplosion = Vector3.Distance(transform.position, Bullet.transform.position);
        float explosionDistanceDivider = distanceToExplosion * ExplosionDistanceDivisionMultiplier;

        Rigidbody.AddForce(explosionDirection * ExplosionRecoilForce / explosionDistanceDivider);
    }




    private void Shoot()
    {
        if (!Bullet.enabled)
        {
            Bullet.transform.position = Gun.transform.position;
            Bullet.transform.rotation = Gun.transform.rotation;
            Bullet.enabled = true;
            Bullet.GetShot();
            Rigidbody.AddForce(-Gun.transform.up * ShotRecoilForce);
            ShotTimer = ShotCooldown;
        }
    }
}
