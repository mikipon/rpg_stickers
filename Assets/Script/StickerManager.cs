using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManager : MonoBehaviour
{

    //public Sprite[] stickers;
    public GameObject[] stickers;
    //public GameObject makeBox;
    public Transform parentTran;
    public float height;

    int count = 0;
    bool m_gameStart;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "sticker")
        {
            Debug.Log(count + ": 通った");

            count++;

            if (count > 10)
            {
                m_gameStart = true;
            }
            else
            {
                m_gameStart = false;
            }

        }
    }

    void Update()
    {
        //Debug.Log(m_gameStart.ToString());
        if (m_gameStart)
        {
            //CreateObject();
        }
        else
        {
            //Debug.Log(m_gameStart.ToString());
            CreateObject();
        }
    }

    void CreateObject()
    {
        int ram = Random.Range(0, stickers.Length);
        int xRam = Random.Range(-9, 10);

        GameObject obj = Instantiate(stickers[ram], new Vector2(xRam, 8), Quaternion.identity);
        //obj.transform.SetParent(parentTran);
        //obj.transform.localPosition = new Vector2(0f, height);

    }

}
