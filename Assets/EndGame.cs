using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

	public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		CameraMovement.escape = true;
		canvas.gameObject.SetActive(true);

	}
}
