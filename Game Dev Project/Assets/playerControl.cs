using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
    public Camera cam;
    private float maxHeight;

    // Use this for initialization
    void Start () {
    if (cam == null) {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetHeight = cam.ScreenToWorldPoint(upperCorner);
        maxHeight = targetHeight.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(-2.75f, rawPosition.y, 0);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3(targetPosition.x, targetHeight, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }
}
