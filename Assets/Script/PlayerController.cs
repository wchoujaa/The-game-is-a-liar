using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody m_rigidbody;

	public float Speed;
    // Start is called before the first frame update
    void Start()
    {
		m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		var camera = Camera.main;
		Vector3 forward = camera.transform.forward * y;
		Vector3 right = camera.transform.right * x;

		forward.y = 0;
		right.y = 0;


		m_rigidbody.velocity = (forward + right) * Speed;

	}
}
