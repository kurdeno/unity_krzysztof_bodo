using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex5 : MonoBehaviour
{
    public GameObject myPrefab;
    public List<(float,float)> cubesCoordinates;
    int counter;
    int counterLimit;
    void Start()
    {
        cubesCoordinates = new List<(float, float)>();
        counter = 0;
        counterLimit = 10;
    }
    void Update()
    {
        if(counter < counterLimit)
        {
            float x, z;
            do
            {
                x = Mathf.Round(Random.value * 9) - 5;
                z = Mathf.Round(Random.value * 9) - 5;
            }
            while (cubesCoordinates.Contains((x, z)));
            Instantiate(myPrefab, new Vector3(x + 0.5f, 0.5f, z + 0.5f), Quaternion.identity);
            cubesCoordinates.Add((x, z));
            counter++;
        }
    }
}

