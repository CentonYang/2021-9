using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Material mat;
    public float fade, fadeVar;
    public PlayerController pc;

    void Start()
    {
        mat = GetComponentInChildren<Renderer>().material;
        pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        fadeVar += fadeVar < fade ? Time.deltaTime : 0;
        mat.SetFloat("_Fade", fadeVar);
        if (pc.gone)
        {
            fade = 0;
            fadeVar = 0;
            GetComponentInChildren<Renderer>().sortingOrder = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.tag == pc.tag && fadeVar == 0)
        {
            fade = 1;
            GetComponentInChildren<Renderer>().sortingOrder = 1;
            pc.coins++;
        }
    }
}
