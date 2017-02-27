using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Let's move towards the mouse.
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouseDir = ((Vector2)mouseWorldPos - (Vector2)transform.position).normalized;

            GameObject newProjectile = Instantiate(bulletPrefab) as GameObject;
            newProjectile.transform.position = transform.position;
            newProjectile.GetComponent<Bullet>().directionToMove = toMouseDir;

            Debug.Log("Im Lost"); 
        }

    }
}
