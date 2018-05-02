using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    private Vector3 targetPos;
    private float step;
    private AudioSource shootAudio;

    private float damage;

    // Use this for initialization
    void Start() {
        targetPos = this.transform.position;
        step = 1.5f;
        shootAudio = gameObject.GetComponent<AudioSource>();
        damage = 50;
    }

    // Update is called once per frame
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, step);
        checkPos();
    }

    public void setTargetPos(Vector3 newTarget) {
        targetPos = newTarget;
        shootAudio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("LimitOfMap")) {
            Destroy(this.gameObject);
        }
    }

    private void checkPos() {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        if (xPos < 0 || yPos < 0 || xPos > 20 || yPos > 20) {
            Destroy(this.gameObject, 0.05f);
        }
    }

    public void setSprite(Sprite sprite) {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public float getDamage() {
        return damage;
    }
}
