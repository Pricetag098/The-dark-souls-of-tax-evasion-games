using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Gun[] guns;
	public Transform head;

	public Transform target;
	Vector3 tLast;

	public LayerMask enemyLayer;

	public float detectionRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Collider[] enemys =  Physics.OverlapSphere(head.position, detectionRadius, enemyLayer);

		Transform nEnemy = target;
		float closest = float.MaxValue;
		if(enemys.Length > 0)
		{
			foreach(Collider enemy in enemys)
			{
				if(Vector3.Distance(enemy.transform.position,head.position) < closest)
				{
					nEnemy = enemy.transform;
					closest = Vector3.Distance(enemy.transform.position, head.position);

				}
			}
			if(nEnemy != target)
			{
				target = nEnemy;
				tLast = target.position;
			}
			
			
		}

		else
		{
			target = null;
		}
		if (target)
		{
			foreach(Gun gun in guns)
			{
				doTargeting(gun);
			}
			

		}
		
    }

	private void LateUpdate()
	{
		if (target)
		{
			tLast = target.position;
		}
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(0,255,0,.1f);
		
		Gizmos.DrawSphere(head.position, detectionRadius);
	}

	void doTargeting(Gun gun)
	{

		Vector3 tVel = (target.position - tLast) * Time.deltaTime;
		Vector3 defAimDir = (target.position - head.position);
		Vector3 newAimDir = (defAimDir + tVel * (tVel.magnitude / gun.bulletSpeed));


		//head.LookAt(target);
		head.transform.forward = newAimDir;
		transform.eulerAngles = new Vector3(0, head.eulerAngles.y, 0);
		gun.transform.eulerAngles = new Vector3(head.eulerAngles.x, transform.eulerAngles.y, 0);
		gun.shoot();
	}
}
