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

    void Start()
    {
        Bullet.enabled = false;
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(ShootKey))
        {
            if (Bullet.enabled)
            {
                Bullet.Explode();
            }
            else
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



    private void Shoot()
    {
        if (!Bullet.enabled)
        {
            Bullet.transform.position = Gun.transform.position;
            Bullet.transform.rotation = Gun.transform.rotation;
            Bullet.enabled = true;
            Bullet.GetShot();
            Rigidbody.AddForce(-Gun.transform.up * ShotRecoilForce);
        }
    }
}
