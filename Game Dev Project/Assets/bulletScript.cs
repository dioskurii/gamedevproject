using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 500;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Fire()
    {
        Rigidbody2D bPrefab = (Rigidbody2D)Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        rb.AddForce(Vector2.up * bulletSpeed);

        coolDown = Time.time + attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= coolDown)
        {
            if (Input.GetMouseButton(0)) {
                Fire();
            }
        }
    }
}