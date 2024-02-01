using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : EnemyBase
{
	private float defaultMoveSpeed;
	private float hitTime;

	[Header("Tank Attributes")]
	[SerializeField] private float hitDelay = 1f;

	private void Start()
	{
		//record default movespeed when spawned
		defaultMoveSpeed = MoveSpeed;
	}

	protected override void OnHit()
    {
		//timestamp hit time and set movespeed to 0
		hitTime = Time.unscaledTime;
		MoveSpeed = 0;
    }

	protected override void Move()
	{
		//check if time has elapsed stun delay since hit, return movespeed to default
		if (Time.unscaledTime >= hitTime + hitDelay)
			MoveSpeed = defaultMoveSpeed;

		base.Move();
	}

	public override void Kill()
    {
        //TODO put code you want to happen before disable here

        // this runs the base method AND what's above it here
        base.Kill();
    }
}
