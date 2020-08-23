﻿using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0.1f;
    private float fireRateTimer;
    public ShipGunBase gun;
    [SerializeField]
    private Vector2 gunOffset;
    
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        fireRateTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (fireRateTimer >= fireRate)
            {
                fireRateTimer = 0;
                gun.Fire((Vector2)transform.position + gunOffset);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + gunOffset, 0.02f);
    }
}