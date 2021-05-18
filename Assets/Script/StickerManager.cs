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
    bool m_displayComp;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "sticker")
        {
            //Debug.Log(count + ": 通った");

            count++;

            if (count == 1)
            {
                m_displayComp = true;
                m_gameStart = true;
                Debug.Log("10個でた");
            }
            else if(count < 1)
            {
                m_displayComp = false;
                m_gameStart = false;
                Debug.Log("それ以外");
            }

        }
    }

    void Update()
    {
        CreateObject(m_displayComp);

        if (m_gameStart) // ステッカーを表示し終えた
        {

        }
    }

    void CreateObject(bool bol)
    {
        if (!bol) {
                int ram = Random.Range(0, stickers.Length);
                int xRam = Random.Range(-1, 1);

                GameObject obj = Instantiate(stickers[ram], new Vector2(xRam, 4), Quaternion.identity);
                //obj.transform.SetParent(parentTran);
                //obj.transform.localPosition = new Vector2(0f, height);]
        }
    }

}
