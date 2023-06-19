using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight, portal;
    public Rigidbody2D rgbd;
    public Animator anim;
    public int coins, timesGone;
    public Material mat;
    public bool isGround, gone;
    public Text coinText;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        mat = GetComponentInChildren<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rgbd.velocity = new Vector2(transform.GetChild(0).localScale.x * speed, rgbd.velocity.y);
            transform.GetChild(0).localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            if (rgbd.velocity.y == 0 && isGround)
                anim.Play("Run");
        }
        else if (rgbd.velocity.y == 0 && isGround)
        {
            rgbd.velocity *= Vector2.right * 0;
            anim.Play("Idle");
        }
        if (Input.GetAxisRaw("Vertical") > 0 && rgbd.velocity.y == 0 && isGround)
        {
            anim.Play("jump");
            rgbd.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        if (rgbd.velocity.y < 0 && !isGround)
            anim.Play("Fall");
        if (transform.GetChild(0).position.y < -4)
        {
            gone = true;
            rgbd.simulated = false;
            portal += Time.deltaTime;
            if (portal >= 1)
            {
                coins = 0; timesGone++;
                gone = false;
                transform.position = Vector2.zero;
                rgbd.simulated = true;
                portal = 0;
            }
            mat.SetFloat("_Portal", portal);
        }
        coinText.text = string.Format("Ä_¥Û: {0} / {1}", coins.ToString("00"), 10);
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
