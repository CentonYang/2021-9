using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Material mat;
    public float triggers;
    public int type;

    void Start()
    {
        mat = GetComponentInChildren<Renderer>().material;
    }

    void Update()
    {
        mat.SetFloat("_Trigger", triggers);
        triggers = Mathf.Lerp(triggers, 0, .02f);
    }

    void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.tag == "Player")
            triggers = 1;
    }
}
