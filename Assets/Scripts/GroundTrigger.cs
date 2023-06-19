using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    public PlayerController pc;

    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.tag == "Ground")
            pc.isGround = true;
    }

    void OnTriggerExit2D(Collider2D cls)
    {
        if (cls.tag == "Ground")
            pc.isGround = false;
    }
}
