using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
	[SerializeField] private Collider _collider;
	[SerializeField] private Renderer _renderer;

	[Header("Stats")]
	[SerializeField] protected float PowerupDuration = 1f;
	private float hitTime;
	private bool powerUp;

	protected TurretController turret;

	protected abstract void PowerUp();
	protected abstract void PowerDown();

	protected void Awake()
	{
		//assign turret
		turret = FindObjectOfType<TurretController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Projectile projectile = other.GetComponent<Projectile>();
		if (projectile != null)
		{
			//activate powerup when hit by projectile, timestamp hit
			PowerUp();
			powerUp = true;
			hitTime = Time.unscaledTime;

			//disable collider and visuals
			_collider.enabled = false;
			_renderer.enabled = false;
		}
	}

	private void FixedUpdate()
	{
		//only check if powerup has been hit - check if time has elapsed duration since hit
		if (powerUp)
			if (Time.unscaledTime >= hitTime + PowerupDuration)
			{
				PowerDown();
				Destroy(gameObject);
			}
	}
}
