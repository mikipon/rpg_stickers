using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerManager : MonoBehaviour
{

    //public Sprite[] stickers;
    public GameObject[] weaponStickers;
    public GameObject[] otherStickers;
    public GameObject[] recoverySticker;
    ////public GameObject makeBox;
    //public Transform parentTran;
    //public float height;
    public int max = 30;
    public bool gameStart;

    private Sprite sprite;
    private bool flg = true;
    private float eneHP;
    private float eneMaxHP;

    PlayerManager _playerManager;
    GameObject _stickerObject;
    EnemiesManager EnemiesManager;
    DamageManager DamageManager;
    Image image;

    int count = 0;
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
                gameStart = true;
                //Debug.Log(count + "全部でた");
            }
            else if (count < 1)
            {
                //m_displayComp = false;
                gameStart = false;
                //Debug.Log("それ以外");
            }

        }
       
        _playerManager.GetBool(gameStart);
        EnemiesManager.GetBool(gameStart); //　なぜこれだけ出来ん？



    }

    /// <summary>
    /// ステッカー生成
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateCube()
    {
        int w_max = 3;
        int o_max = max - w_max;

        //武器のSticker生成
        for (int count = 0; count < w_max; count++)
        {
            int ram = Random.Range(0, weaponStickers.Length);
            int xRam = Random.Range(-6, 7);
            float tRam = Random.Range(0.0f, 0.6f);

            yield return new WaitForSeconds(tRam);
            Instantiate(weaponStickers[ram], new Vector2(xRam, 6), Quaternion.identity);
        }

        //ダミーSticker生成
        for (int count = 0; count < o_max; count++)
        {
            int ram = Random.Range(0, weaponStickers.Length);
            Random rnd = new Random();
            int xRam = Random.Range(-6, 7);
            yield return new WaitForSeconds(0.1f);
            Instantiate(otherStickers[ram], new Vector2(xRam, 6), Quaternion.identity);
        }

    }

    void Start()
    {
        try
        {
            StartCoroutine("CreateCube");
            _playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            GameObject image_object = GameObject.Find("Image");
            image = image_object.GetComponent<Image>();
            DamageManager = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            EnemiesManager = GameObject.Find("EnemiesManager").GetComponent<EnemiesManager>();
        }
        catch (System.NullReferenceException)
        {

        }
    }

    void Update()
    {
        //p_HP = _playerManager._hp;
        //Debug.Log("NOW : " + p_HP);

        //eneHP = EnemiesManager.eneHP;
        //eneMaxHP = EnemiesManager.eneMaxHP;

        //Debug.Log("NOW : " + EnemiesManager.eneHP);

        if (gameStart) // ステッカーを表示し終えた
        {
            

            //回復Sticker生成
            if (_playerManager.wantRecovery && flg == true)
            {
                Debug.Log("薬欲しい");
                int ram = Random.Range(0, recoverySticker.Length);
                Random rnd = new Random();
                int xRam = Random.Range(-6, 7);
                Instantiate(recoverySticker[ram], new Vector2(xRam, 6), Quaternion.identity);
                flg = false;
            }

        }
        else
        {
            //Debug.Log("Not GameStart");
        }
    }

    public void Display(GameObject gameObject)
    {
        sprite = Resources.Load<Sprite>(gameObject.name.Replace("(Clone)", ""));
        image.sprite = sprite;
    }


}
