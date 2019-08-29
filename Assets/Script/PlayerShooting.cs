using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public int damagePerShot = 20;                  // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.15f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.

	float timer;                                    // A timer to determine when to fire.
	Ray shootRay;                                   // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
	public ParticleSystem gunParticles;                    // Reference to the particle system.
	public LineRenderer gunLine;                           // Reference to the line renderer.
	public AudioSource gunAudio;                           // Reference to the audio source.
	public	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	public Animator gunAnimator;
	public GameObject bullet_spawn;
	void Awake()
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask("Shootable");

		// Set up the references.

	}

	void Update()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// If the Fire1 button is being press and it's time to fire...
		if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
		{
			// ... shoot the gun.
			StartCoroutine(ShootAnimation());
			Shoot();
		} else
		{

		}

		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if (timer >= timeBetweenBullets * effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects();

		}
	}

	IEnumerator ShootAnimation()
	{
		gunAnimator.SetBool("shooting", true);


		yield return new WaitForSeconds(1.0f);
		gunAnimator.SetBool("shooting", false);

	}

	public void DisableEffects()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
		//gunParticles.Stop();
	}

	void Shoot()
	{
		// Reset the timer.
		timer = 0f;

		// Play the gun shot audioclip.
		gunAudio.Play();

		// Enable the light.
		gunLight.enabled = true;
		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Play();

		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;

		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		shootRay.origin = bullet_spawn.transform.position;
		shootRay.direction = transform.position + transform.forward * 1000;
		gunLine.SetPosition(0, bullet_spawn.transform.position);


		Debug.DrawLine(transform.position, transform.position + transform.forward*10);


		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{

			// Try and find an EnemyHealth script on the gameobject hit.
			AController enemyHealth = shootHit.collider.GetComponent<AController>();

			// If the EnemyHealth component exist...
			if (enemyHealth != null)
			{
				// ... the enemy should take damage.
				enemyHealth.TakeDamage(damagePerShot, shootHit.point);
			}

			// Set the second position of the line renderer to the point the raycast hit.
			gunLine.SetPosition(1, shootHit.point);
		}
		// If the raycast didn't hit anything on the shootable layer...
		else
		{
			// ... set the second position of the line renderer to the fullest extent of the gun's range.
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
