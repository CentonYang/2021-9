using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transer : MonoBehaviour
{
    public List<Material> mats;
    public float state, stateVar;

    void Start()
    {
        foreach (Renderer item in GetComponentsInChildren<Renderer>())
            mats.Add(item.material);
    }

    void Update()
    {
        stateVar = Mathf.Lerp(stateVar, state, .05f);
        foreach (Material mat in mats)
        {
            mat.SetFloat("_State", stateVar);
            if (state < 0.01)
            {
                mat.SetInt("_SurfaceType", 0);
                mat.SetInt("_RenderQueueType", 1);
            }
            else
            {
                mat.SetInt("_SurfaceType", 1);
                mat.SetInt("_RenderQueueType", 4);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.tag == "Player")
            state = 1;
    }

    void OnTriggerExit2D(Collider2D cls)
    {
        if (cls.tag == "Player")
            state = 0;
    }
}
