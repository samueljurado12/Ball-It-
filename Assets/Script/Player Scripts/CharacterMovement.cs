using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    // TODO Add direction as variable, pass it to playerMngr when shot

    private float currentSpeed, movementSpeed, dashSpeed, cdDash, cdShot; // TODO ORGANIZATION!!!
    private bool canDash, canShot;
    private PlayerManager playerMngr;
    private string playerNumber;
    private Vector3 movementDir;

	// Use this for initialization
	void Start () {
        movementDir = Vector3.zero;
        movementSpeed = 15;
        dashSpeed = 1.5f * movementSpeed;
        currentSpeed = movementSpeed;
        canDash = true;
        canShot = true;
        cdDash = 5;
        cdShot = 0.75f;
        playerMngr = gameObject.GetComponentInParent<PlayerManager>();
        playerNumber = getPlayerNumber(playerMngr.tag);
    }
	
	// Update is called once per frame
	void Update () {
        move();
        dash();
        shoot();
        if (Input.GetButtonDown("Start" + playerNumber)) {
            Debug.Log(playerNumber + " wants to pause.");
        }
    }

    // Basic movement of the player
    private void move() {
        movementDir = getPlayerDirection();
        transform.Translate(movementDir * currentSpeed * Time.deltaTime);
    }

    private Vector3 getPlayerDirection() {
        String verticalAxis = "Vertical" + playerNumber;
        String horizontalAxis = "Horizontal" + playerNumber;
        Vector3 vertical = Vector3.up * Input.GetAxis(verticalAxis);
        Vector3 horizontal = Vector3.right * Input.GetAxis(horizontalAxis);
        return vertical + horizontal;
    }

    // Dash function (NF)
    private void dash() { // TODO Add invulnerability during dash
        if (Input.GetAxis("Trigger" + playerNumber) > 0 && canDash) { 
            canDash = false;
            currentSpeed = dashSpeed;
            Invoke("resetSpeed", 0.25f);
            Invoke("resetDash", cdDash);
        }
    }

    //Shoot function
    private void shoot() { 
        if(Input.GetAxis("Trigger" + playerNumber) < 0 && canShot) {
            canShot = false;
            playerMngr.shotFired(movementDir);
            Invoke("resetShot", cdShot);
        }
    }

    // Reset current speed to movementSpeed
    private void resetSpeed() { 
        currentSpeed = movementSpeed;
    }

    // Reset canDash property
    private void resetDash() { 
        canDash = true;
        Debug.Log("Dash ready");// TODO remove, add visual warning
    }

    // Reset canShot property
    private void resetShot() {
        canShot = true;
        Debug.Log("Shot ready"); // TODO remove, add visual warning
    }

    private string getPlayerNumber(String tag) {
        string index = tag[tag.Length - 1].ToString();
        return index;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ProjectileMovement proj = collision.gameObject.GetComponent<ProjectileMovement>();
        if (proj) {
            //Recibe daño
            Debug.Log(playerMngr.tag + ": me hisiste daño");
            Destroy(proj.gameObject);
        }
    }
}
