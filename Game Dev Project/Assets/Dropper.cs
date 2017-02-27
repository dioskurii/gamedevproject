using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

    public float timeToDrop = 60;
    public GameObject enemies;
    public float maxTimer = 300;
    public float score = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToDrop--;
        if (timeToDrop <= 0)
        {
            // spawn a falling block

            GameObject newProjectile = Instantiate(enemies, transform.position, transform.rotation) as GameObject;

            // Debug.Log("block time"); // old thing to see if i was actually spawning blocks or being a doof
            timeToDrop = Random.Range(30, maxTimer);
        }
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
        score++;
        Debug.Log("Point!!");
    }

}
