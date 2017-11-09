﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{

    public int health = 100;
    float movementSpeed = 10f;
    float damage = 10f;
    float renderDistance = 100f; // Distance from the player before the renderer will activate.
    float destinationChangeDistance = 50f; // Distance from the player before the path will change to dirrectly follow the player.
    public NavMeshAgent Ai;
    MeshRenderer rend;
    public GameObject target1; // Player
    public GameObject target2; // Location near player.
    public bool target1Spotted; // Use to change between navmesh Paths
    public bool target2Spotted = true; // Default
    public GameObject gameManagersReference;
    public float score = 5f;

    public virtual void Start()
    {
        gameManagersReference = GameObject.FindGameObjectWithTag("GM");
        rend = GetComponent<MeshRenderer>();

        // Setting up AI.
        Ai = gameObject.GetComponent<NavMeshAgent>(); // Ai = navmeshagent attached to the gameobject
        Ai.speed = movementSpeed;

        // Setting up targets
        target1 = GameObject.FindGameObjectWithTag("Player");
       // target2 = GameObject.FindGameObjectWithTag("NetworkedPlayer");

        
    }

    public void Death()
    {
        if(health <= 0)
        {
            SurvivalSystem reference = gameManagersReference.GetComponentInChildren<SurvivalSystem>();
            reference.lifeTimer += score;
            Destroy(gameObject);          
        }
    }
    
    public virtual void Update()
    {

        Death();

        // IF distance is too far from the player, disable mesh renderer
        /// Fog will be present, this is an attempt to optimise ((might be impactful if proper models were used)), hide unseen enemies.
        /// 
        if(Vector3.Distance(gameObject.transform.position,target1.transform.position) > renderDistance)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }

        
        if(target1Spotted == true)
        {
            Ai.SetDestination(target1.transform.position); // Within update, it will update with the player movements to follow them.
        }

        if(target2Spotted == true)
        {

        }
    }


    public virtual void OnDrawGizmos()
    {

    }
}
