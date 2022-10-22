using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{
    public GameObject myPrefab;
    int one_sec = 0;
    int counter = 0;
    int index_decrement = 0;
    
    ArrayList valid_x_choices = new ArrayList()
                {
                    -4.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f
                };
    ArrayList valid_z_choices = new ArrayList()
                {
                    -4.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f
                };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    (float a, float b) ChooseUntakenCoords(int len)
    {
        int index_x = Random.Range(0, len);
        int index_z = Random.Range(0, len);
        float x_value = (float)valid_x_choices[index_x];
        float z_value = (float)valid_z_choices[index_z];
        valid_x_choices.RemoveAt(index_x);
        valid_z_choices.RemoveAt(index_z);
        return (x_value, z_value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        one_sec += 1;
        if (one_sec>=25 && counter <10)
        {
            (float x, float z) = ChooseUntakenCoords(9-index_decrement);
            index_decrement += 1;
            Instantiate(myPrefab, new Vector3(x, 2, z), Quaternion.identity);
            one_sec = 0;
            counter += 1;
        }
        
    }
}
