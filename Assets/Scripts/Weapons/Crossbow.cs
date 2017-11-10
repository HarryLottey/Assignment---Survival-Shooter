using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
    [SerializeField]
    Camera cam;

    public Transform ProjectileOrigin;
    public GameObject boltPrefab;
    public float fireDistance;
    public LayerMask attackable; // Weapon raycasts on this layer


    // Use this for initialization
    void Awake()
    {

        boltPrefab = Resources.Load("ArrowTemp") as GameObject;

        cam = Camera.main;
        if (attackable != 1 << LayerMask.NameToLayer("enemy")) // 1 << 8
            attackable = 1 << LayerMask.NameToLayer("enemy"); // Set our layer to enemy if it does not by default.
    }

    public override void Fire()
    {
       
        if (ammo > 0)
        {
            Instantiate(boltPrefab, ProjectileOrigin.transform.position, transform.localRotation);                           
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * fireDistance);
    }

    public override void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || ammo <= 0)
        { // Manual reload, or when we are out of ammo
            StartCoroutine(CrossbowReload());
            if (ammo == maxAmmo)
                StopCoroutine(CrossbowReload());
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (blessedWeapon)
        {
            damage = 115;
            fireInterval = 0.6f;
            reloadSpeed = 1.5f;
        }
        else
        {
            reloadSpeed = 4f;
            damage = 45;
            fireInterval = 0.3f;
        }


        if (ammo < maxAmmo)
            Reload();
    }

    IEnumerator CrossbowReload()
    {
        yield return new WaitForSeconds(1.4f);
        ammo += 1;
        
        
        // revisit when I have time to make it proper
    }

}
