using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public int generatedAmount;
    public GameObject plane;
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    List<Material> materials = new List<Material>();
    

    void Start()
    {
        materials.Add(material1);
        materials.Add(material2);
        materials.Add(material3);
        materials.Add(material4);
        materials.Add(material5);
        Collider planeCollider = plane.GetComponent<Collider>();
        List<float> pozycje_x = new List<float>();
        List<float> pozycje_z = new List<float>();
        // w momecie uruchomienia generuje generatedAmount kostek w losowych miejscach
        for (int i = 0; i < generatedAmount; i++)
        {
            pozycje_x.Add(UnityEngine.Random.Range(planeCollider.bounds.min[0], planeCollider.bounds.max[0]));
            pozycje_z.Add(UnityEngine.Random.Range(planeCollider.bounds.min[2], planeCollider.bounds.max[2]));
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
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
            block.GetComponent<MeshRenderer>().material = materials[UnityEngine.Random.Range(0, 4)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
