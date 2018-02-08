using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class controls messages between player input and projectile movement
public class PlayerManager : MonoBehaviour {

    private CharacterMovement player;
    private ProjectileMovement projectile;
    private float shotDistance; //TODO think another variable name

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInChildren<CharacterMovement>();
        projectile = gameObject.GetComponentInChildren<ProjectileMovement>();
        shotDistance = 5f;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player.transform.position);
        //Debug.Log(projectile.transform.position);
    }

    public void shotFired() {
        projectile.setTargetPos(calculateTargetPosProjectile(player.transform.position, projectile.transform.position));
    }

    private Vector3 calculateTargetPosProjectile(Vector3 playerPos, Vector3 projectilePos) {
        Vector3 targetPosition = Vector3.zero;
        
        //Calculate magnitude of Vector from projectile start position over player position
        Vector3 d1 = playerPos - projectilePos;
        float normaD1 = Vector3.Magnitude(d1);

        //Calculate components of Vector from player position over projectile target position
        float dx2 = (shotDistance * d1.x)/normaD1;
        float dy2 = (shotDistance* d1.y)/ normaD1;
        
        //Assign components to target position
        targetPosition.x = playerPos.x + dx2;
        targetPosition.y = playerPos.y + dy2;

        return targetPosition;
    }
}
