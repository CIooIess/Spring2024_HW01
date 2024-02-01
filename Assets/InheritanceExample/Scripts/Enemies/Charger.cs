using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Charger : EnemyBase
{
	[SerializeField] private GameObject powerUpDrop;

    protected override void OnHit()
    {
		//increase speed when hit
		MoveSpeed *= 2;
    }

    public override void Kill()
    {
		Instantiate(powerUpDrop, transform.position, Quaternion.identity);

        // this runs the base method AND what's above it here
        base.Kill();
    }
}
