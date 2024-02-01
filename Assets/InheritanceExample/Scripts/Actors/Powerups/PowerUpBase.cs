using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
	[SerializeField] protected float PowerupDuration = 1f;
	private float hitTime;
	private bool powerUp;

	[SerializeField] protected Collider _collider;
	[SerializeField] protected Renderer _renderer;

	protected abstract void PowerUp();
	protected abstract void PowerDown();

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
