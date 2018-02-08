using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    private Vector3 targetPos;
    private float step;

    // Use this for initialization
    void Start() {
        targetPos = this.transform.position;
        step = 1.5f;
    }

    // Update is called once per frame
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, step);
    }

    public void setTargetPos(Vector3 newTarget) {
        targetPos = newTarget;
    }
}
