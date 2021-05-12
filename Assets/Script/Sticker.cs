using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Sprite[] stickers;
    public GameObject makeBox;

    int count = 0;
    bool gameStart;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sticker")
        {
            count ++;

            if (count == 20)
            {
                gameStart = true;
            }

        }
    }

    void Update()
    {
        if (gameStart)
        {
            int xRam = Random.Range(-9, 10); // 生成位置Xをランダム
            int stiRam = Random.Range(0, stickers.Length); // 生成するステッカーをランダム

            for (int i = 0; i < stickers.Length; i++)
            {
                GameObject temp = Instantiate(makeBox, new Vector2(xRam, 8), Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().sprite = stickers[stiRam];
                temp.GetComponent<Rigidbody2D>().gravityScale = 2;
            }
        }    
    }



}
