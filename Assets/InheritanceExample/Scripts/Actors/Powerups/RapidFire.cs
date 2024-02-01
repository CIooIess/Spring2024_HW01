using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
	[Header("Rapid Fire")]
	[SerializeField] private AudioClip _speedIncrease;

	protected override void PowerUp()
	{
		//double firerate
		turret.FireCooldown /= 2;

		AudioHelper.PlayClip2D(_speedIncrease, 1, .1f);
	}

	protected override void PowerDown()
	{
		//reverse effect of powerup
		turret.FireCooldown *= 2;
	}
}
