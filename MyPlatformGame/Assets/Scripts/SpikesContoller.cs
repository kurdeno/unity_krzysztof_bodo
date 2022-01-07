using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesContoller : MonoBehaviour
{
	public HealthScript Health;
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player") == true)
		{
			Health.DeleteLife();
		}
	}
}
