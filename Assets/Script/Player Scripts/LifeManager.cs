using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {
    public LevelManager levelManager;

    private float maxLife, currentLife;
    private UIManager guiManager;

	// Use this for initialization
	void Start () {
        maxLife = 200;
        currentLife = maxLife;
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        ProjectileMovement proj = collision.gameObject.GetComponent<ProjectileMovement>();
        if (proj) {
            currentLife -= proj.getDamage();
            Destroy(proj.gameObject);
            if(currentLife <= 0) {
                levelManager.LoadLevel("04_EndOfGame");
            }
            guiManager.updateLife(currentLife);
        }
    }
}
