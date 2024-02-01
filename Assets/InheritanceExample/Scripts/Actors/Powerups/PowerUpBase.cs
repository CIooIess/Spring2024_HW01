using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
	protected TurretController turret;

	[SerializeField] protected float PowerupDuration = 1f;
	private float hitTime;
	private bool powerUp;

	[SerializeField] protected Collider _collider;
	[SerializeField] protected Renderer _renderer;

	protected abstract void PowerUp();
	protected abstract void PowerDown();

	protected void Awake()
	{
		turret = FindObjectOfType<TurretController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Projectile projectile = other.GetComponent<Projectile>();
		if (projectile != null)
		{
			PowerUp();
			powerUp = true;
			hitTime = Time.unscaledTime;
			_collider.enabled = false;
			_renderer.enabled = false;
		}
	}

	private void FixedUpdate()
	{
		if (powerUp)
			if (Time.unscaledTime >= hitTime + PowerupDuration)
			{
				PowerDown();
				Destroy(gameObject);
			}
	}
}
