using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private float currentSpeed, movementSpeed, dashSpeed;
    private bool canDash;

	// Use this for initialization
	void Start () {
        movementSpeed = 13;
        dashSpeed = 1.5f * movementSpeed;
        currentSpeed = movementSpeed;
        canDash = true;
    }
	
	// Update is called once per frame
	void Update () {
        move();
        dash();
        shoot();
    }

    private void shoot() {
        // TODO Implementar funcion
    }

    private void dash() {
        // si boton dash es pulsado y puedo hacer el dash
            // No puedo hacer el dash
            // cambio la velocidad
            // reseteo la velocidad con un retraso
            // reseteo el poder dashear con un retraso
        if (Input.GetButtonDown("Submit") && canDash) {
            canDash = false;
            currentSpeed = dashSpeed;
            Invoke("resetSpeed", 0.25f);
            Invoke("resetDash", 5);
        }
    }

    private void resetSpeed() {
        currentSpeed = movementSpeed;
    }

    private void resetDash() {
        canDash = true;
        Debug.Log("Dash listo");
    }

    private void move() {
        Vector3 vertical = Vector3.up * Input.GetAxis("Vertical");
        Vector3 horizontal = Vector3.right * Input.GetAxis("Horizontal");

        transform.Translate((vertical + horizontal) * currentSpeed * Time.deltaTime);
    }
}
