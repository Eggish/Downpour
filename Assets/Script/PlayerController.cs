using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody = null;
    [SerializeField] private GameObject Gun = null;
    [SerializeField] private Bullet BulletPrefab = null;

    private List<Bullet> Bullets = new List<Bullet>();

    [SerializeField] private KeyCode ShootKey = KeyCode.Mouse0;

    [SerializeField] private float ShotRecoilForce = 50.0f;

    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            Bullet newBullet = Instantiate(BulletPrefab, transform);
            newBullet.gameObject.SetActive(false);

            Bullets.Add(newBullet);
        }
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(ShootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        foreach(Bullet b in Bullets)
        {
            if (!b.gameObject.activeInHierarchy)
            {
                b.transform.position = Gun.transform.position;
                b.transform.rotation = Gun.transform.rotation;
                b.gameObject.SetActive(true);
                Rigidbody.AddForce(-Gun.transform.right * ShotRecoilForce);
                break;
            }
        }
    }
}
