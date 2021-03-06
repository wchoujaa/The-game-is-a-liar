using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class CameraMovement : MonoBehaviour
{

	[SerializeField]
	public float sensitivity = 5.0f;
	[SerializeField]
	public float smoothing = 2.0f;
	// the chacter is the capsule
	public GameObject character;
	// get the incremental value of mouse moving
	private Vector2 mouseLook;
	// smooth the mouse moving
	private Vector2 smoothV;

	public static bool escape;

	// Use this for initialization
	void Awake()
	{
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			escape = !escape;
		} 

		if (escape == true)
		{
			Cursor.lockState = CursorLockMode.None;

			return;
		}




		Cursor.lockState = CursorLockMode.Locked;

		// md is mosue delta
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		// the interpolated float result between the two float values
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		// incrementally add to the camera look
		mouseLook += smoothV;

		// vector3.right means the x-axis
		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right) ;
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x -90, character.transform.up);
	}
}