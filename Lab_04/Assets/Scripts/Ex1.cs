using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Ex1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectLimit;
    // obiekt do generowania
    public GameObject block;

    public List<Material> materials;
    

    void Start()
    {
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<float> pozycje_x = new List<float>();
        List<float> pozycje_z = new List<float>();
        Vector3 ramPlaneSize = GetComponent<MeshRenderer>().bounds.size;


        for (int i = 0; i < objectLimit; i++)
        {
            pozycje_x.Add(Mathf.Round(UnityEngine.Random.value * (ramPlaneSize.x -1 ) - ramPlaneSize.x/2)+ 0.5f);
            pozycje_z.Add(Mathf.Round(UnityEngine.Random.value * (ramPlaneSize.z - 1) - ramPlaneSize.z / 2) + 0.5f);
            Debug.Log(pozycje_x.Last());
            Debug.Log(pozycje_z.Last());

            this.positions.Add(new Vector3(
                this.transform.position.x + pozycje_x[i],
                5,
                this.transform.position.z + pozycje_z[i]
                ));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            int x = (int)Mathf.Round(UnityEngine.Random.value * 4);
            this.block.GetComponent<MeshRenderer>().material = this.materials[x];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
