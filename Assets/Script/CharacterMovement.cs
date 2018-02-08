using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private float currentSpeed, movementSpeed, dashSpeed, cdDash, cdShot; // TODO ORGANIZATION!!!
    private bool canDash, canShot;
    private PlayerManager playerMngr;
    private string playerNumber;

	// Use this for initialization
	void Start () {
        movementSpeed = 13;
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
        Debug.Log(playerNumber);
        move();
        dash();
        shoot();
    }

    // Basic movement of the player (NF)
    private void move() {
        String verticalAxis = "Vertical" + playerNumber; // TODO change inline def to auto player assignment 
        String horizontalAxis = "Horizontal" + playerNumber; // TODO change inline def to auto player assignment
        Vector3 vertical = Vector3.up * Input.GetAxis(verticalAxis);
        Vector3 horizontal = Vector3.right * Input.GetAxis(horizontalAxis);

        transform.Translate((vertical + horizontal) * currentSpeed * Time.deltaTime);
    }

    // Dash function (NF)
    private void dash() {
        if (Input.GetAxis("Trigger" + playerNumber) > 0 && canDash) { // TODO change inline def to auto player assignment
            canDash = false;
            currentSpeed = dashSpeed;
            Invoke("resetSpeed", 0.25f);
            Invoke("resetDash", cdDash);
        }
    }

    //Shoot function (NF)
    private void shoot() {
        if(Input.GetAxis("Trigger" + playerNumber) < 0 && canShot) { // TODO change inline def to auto player assignment
            canShot = false;
            playerMngr.shotFired();
            Invoke("resetShot", cdShot);
            Debug.Log("Shots fired!!");
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
    
}
