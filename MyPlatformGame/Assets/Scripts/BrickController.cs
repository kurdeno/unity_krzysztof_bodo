using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
	// Start is called before the first frame update

	public GameObject coinPrefab;

	private int coinCounter = 0;
	public int maxCoinNumber = 3;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player") == true && coinCounter<maxCoinNumber)
		{
			coinCounter++;
			var coin = Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
			var coins = GameObject.Find("Collectables");
			coin.transform.parent = coins.transform;
		}
	}
}
