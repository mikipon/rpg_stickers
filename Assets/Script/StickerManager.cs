using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManager : MonoBehaviour
{

    //public Sprite[] stickers;
    public GameObject[] weaponStickers;
    public GameObject[] otherStickers;
    public GameObject[] recoverySticker;
    //public GameObject makeBox;
    public Transform parentTran;
    public float height;
    public int max = 30;

    int count = 0;
    bool m_gameStart;
    //bool m_displayComp;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "sticker" || other.tag == "weapon")
        {
            //Debug.Log(count + ": 通った");

            count++;

            if (count == max)
            {
                //m_displayComp = true;
                m_gameStart = true;
                Debug.Log(count + "全部でた");
            }
            else if(count < 1)
            {
                //m_displayComp = false;
                m_gameStart = false;
                Debug.Log("それ以外");
            }

        }
    }

    void Start()
    {
        StartCoroutine("CreateCube");
    }

    void Update()
    {
        //StartCoroutine("CreateCube");

        if (m_gameStart) // ステッカーを表示し終えた
        {

        }
    }

    /// <summary>
    /// ステッカー生成
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateCube()
    {
        int w_max = 1;
        int o_max = max - w_max;
        for (int count = 0; count < w_max; count++) {
            int ram = Random.Range(0, weaponStickers.Length);
            int xRam = Random.Range(-6, 7);

            yield return new WaitForSeconds(0.5f);
            Instantiate(weaponStickers[ram], new Vector2(xRam, 6), Quaternion.identity);
        }

        for (int count = 0; count < o_max; count++)
        {
            int ram = Random.Range(0, weaponStickers.Length);
            Random rnd = new Random();
            int xRam = Random.Range(-6, 7);
            yield return new WaitForSeconds(0.1f);
            Instantiate(otherStickers[ram], new Vector2(xRam, 6), Quaternion.identity);
        }
    }

}
