using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	public Dialogue dialogue;


	 void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;
		DialogueManager manager = FindObjectOfType<DialogueManager>();
		manager.StartDialogue(dialogue, gameObject);
	}
}
