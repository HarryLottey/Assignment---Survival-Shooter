using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    [SerializeField]
    Camera cam;

    
    public float fireDistance;
    public LayerMask attackable; // Weapon raycasts on this layer


    // Use this for initialization
    void Awake()
    {
        cam = Camera.main;
        if(attackable != 1 << LayerMask.NameToLayer("enemy")) // 1 << 8
            attackable = 1 << LayerMask.NameToLayer("enemy"); // Set our layer to enemy if it does not by default.
    }

    public override void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, fireDistance,attackable))
        {
            
            Enemy kill = hit.transform.GetComponent<Enemy>();
            kill.health -= damage;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * fireDistance);
    }

    public override void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R) || ammo <= 0)
        { // Manual reload, or when we are out of ammo
            StartCoroutine(RevolveReload());
            if (ammo == maxAmmo)
                StopCoroutine(RevolveReload());
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

        

        Reload();
    }

    IEnumerator RevolveReload()
    {
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        // revisit when I have time to make it proper
    }

   
}
