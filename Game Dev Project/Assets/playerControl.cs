using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public Camera cam;
    private float maxHeight;

    public bulletScript other;

    // arthurs fault
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 500;
    public Rigidbody2D rb;
    // all of it

    public void Fire()
    {
        Rigidbody2D bPrefab = (Rigidbody2D)Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        rb.AddForce(Vector2.up * bulletSpeed);

        coolDown = Time.time + attackSpeed;
    }



    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetHeight = cam.ScreenToWorldPoint(upperCorner);
        maxHeight = targetHeight.y;

        GetComponent<bulletScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(-2.75f, rawPosition.y, 0);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3(targetPosition.x, targetHeight, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);





        if (Time.time >= coolDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }




    }
}
