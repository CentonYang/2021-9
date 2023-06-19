using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public PlayerController pc;
    public Material mat;
    public Canvas can;
    public Text info;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        transform.localScale = new Vector3(pc.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        info.rectTransform.localScale = new Vector3(transform.localScale.x, 1, 1);
        if (pc.coins < 10)
            info.text = string.Format("�o���񦳦h���_�۩O�H\n�����٦�{0}�ӧa�H", 10 - pc.coins);
        else
            info.text = string.Format("�ڬݬ�...\n�A���Ҧ��_�ۤF�I\n�b�����e�A\n�A���͹L{0}���C", pc.timesGone);
    }

    void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.tag == pc.tag)
        {
            mat.SetInt("_Trigger", 1);
            can.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D cls)
    {
        if (cls.tag == pc.tag)
        {
            mat.SetInt("_Trigger", 0);
            can.gameObject.SetActive(false);
        }
    }
}
