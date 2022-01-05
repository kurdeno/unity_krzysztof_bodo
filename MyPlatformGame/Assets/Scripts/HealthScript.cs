using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthScript : MonoBehaviour
{
    public int health = 3;
    public GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.Find("PlayerGPX");
    }

    public void DeleteLife()
    {
        if(health ==3)
        {
            var hearth = GameObject.Find("Life3");
            Destroy(hearth);
            player.transform.position = new Vector3(-4f, 4f, 0);
            health--;
        }
        else if(health ==2)
        {
            var hearth = GameObject.Find("Life2");
            Destroy(hearth);
            player.transform.position = new Vector3(-4f, 4f, 0);
            health--;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
