using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_RandomSeed", Random.Range(.0f, 10.0f));
        transform.localScale = Vector3.one * Random.Range(.1f, .4f);
    }

    void Update()
    {

    }
}
