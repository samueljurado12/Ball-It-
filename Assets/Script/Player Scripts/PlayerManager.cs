using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class controls messages between player input and projectile movement
public class PlayerManager : MonoBehaviour {

    public ProjectileMovement projectilePrefab;

    private CharacterMovement player;
    private ProjectileMovement projectile;
    private float shotDistance; //TODO think another variable name
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInChildren<CharacterMovement>();
        shotDistance = 5f;
    }

    public void shotFired(Vector3 movementDir) { // TODO Revise function using pointers (IEnumerator)
        if (projectile) {
            projectile.setTargetPos(calculateSecondShotPosProjectile(player.transform.position, projectile.transform.position));
        } else {
            direction = movementDir;
            projectile = Instantiate(projectilePrefab, player.transform);
            projectile.transform.SetParent(this.transform);
            Invoke("setProjectileTarget", Time.deltaTime);
        }
    }
    private void setProjectileTarget() {
        projectile.setTargetPos(calculateFirstShotPosProjectile(direction));
    }

    private Vector3 calculateFirstShotPosProjectile(Vector3 direction) {
        Vector3 finalPos = Vector3.zero;
        
        float normaRefVector = direction.magnitude;
        float dx2 = 0;
        float dy2 = 0;
        if (normaRefVector != 0) { 
            dx2 = (shotDistance * direction.x) / normaRefVector;
            dy2 = (shotDistance * direction.y) / normaRefVector;
        }

        finalPos.x = projectile.transform.position.x + dx2;
        finalPos.y = projectile.transform.position.y + dy2;

        return finalPos;
    }

    private Vector3 calculateSecondShotPosProjectile(Vector3 playerPos, Vector3 projectilePos) {
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
