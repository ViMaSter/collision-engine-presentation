using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Vector3 Pivot;
    public Vector3 Offset;
    public float Distance = 2.0f;
    public float MouseMoveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Offset += new Vector3(
            Input.GetAxisRaw("Mouse Y")*-1,
            Input.GetAxisRaw("Mouse X")*-1,
            0.0f
        );

        transform.position = Pivot;
        transform.eulerAngles = Offset;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            0.0f
        );

        transform.position += transform.TransformDirection(Vector3.forward * Distance);

        transform.LookAt(Pivot);
	}
}
