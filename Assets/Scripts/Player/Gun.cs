using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;

    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float reloadTime = 1f;
    
    bool bulletLoaded = true;

    [SerializeField] int ammo = 10;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletLoaded)
        {   
            ShootBullet();
        }    
    }

    private void ShootBullet()
    {
        var bulletInstance = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
        bulletRb.AddForce(gameObject.transform.up * bulletSpeed, ForceMode.Impulse);
    }
}
