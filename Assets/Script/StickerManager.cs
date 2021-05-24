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

    private Sprite sprite;

    PlayerManager _playerManager;
    GameObject _stickerObject;
    Image image;
    bool _gameStart;

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
                _gameStart = true;
                //Debug.Log(count + "全部でた");
            }
            else if (count < 1)
            {
                //m_displayComp = false;
                _gameStart = false;
                //Debug.Log("それ以外");
            }

        }
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

        //武器以外のSticker生成
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
        StartCoroutine("CreateCube");
        _playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        GameObject image_object = GameObject.Find("Image");
        image = image_object.GetComponent<Image>();
    }

    void Update()
    {
        if (_gameStart) // ステッカーを表示し終えた
        {
            try{
                _stickerObject = _playerManager.MouseClick();

                if (_stickerObject.tag == "sticker")
                {
                    //Debug.Log("その他のステッカー、何もなし");
                    ClickOther(_stickerObject);
                }
                else if (_stickerObject.tag == "weapon")
                {
                    //Debug.Log("武器ステッカー、攻撃");
                    ClickWeapon(_stickerObject, _playerManager.mouseClick);
                }
                else
                {
                    Debug.Log("null");
                }
            }
            catch (System.NullReferenceException) // why null??
            {
                //Debug.Log("NullReferenceException");
            }
        }
        else
        {
            //Debug.Log("Not GameStart");
        }
    }

    /// <summary>
    /// プレイヤーがクリックした武器Sticker
    /// </summary>
    /// <param name="gameObject"></param>
    void ClickWeapon(GameObject gameObject, bool bo)
    {
        //Debug.Log(gameObject.name.ToString());
        if (bo)
        {
            if (gameObject.name == "Arrow(Clone)")
            {
                Debug.Log("Arrow");
                _playerManager.mouseClick = false;
                Display(gameObject);
                _playerManager.Damage(10);
            }
            else if (gameObject.name == "Axe(Clone)")
            {
                Debug.Log("Axe");
                _playerManager.mouseClick = false;
                Display(gameObject);
                _playerManager.Damage(10);
            }
            else if (gameObject.name == "Cannon(Clone)")
            {
                Debug.Log("Cannon");
                _playerManager.mouseClick = false;
                Display(gameObject);
                _playerManager.Damage(10);
            }
            else if (gameObject.name == "Gun(Clone)")
            {
                Debug.Log("Gun");
                _playerManager.mouseClick = false;
                Display(gameObject);
                _playerManager.Damage(10);
            }
            else if (gameObject.name == "JapaneseSword(Clone)")
            {
                Debug.Log("JapaneseSword");
                _playerManager.mouseClick = false;
                Display(gameObject);
                _playerManager.Damage(10);
            }
        }
    }

    void Display(GameObject gameObject)
    {
        sprite = Resources.Load<Sprite>(gameObject.name.Replace("(Clone)", ""));
        image.sprite = sprite;
    }

    /// <summary>
    /// プレイヤーがクリックした武器以外Sticker
    /// </summary>
    /// <param name="gameObject"></param>
    void ClickOther(GameObject gameObject)
    {

    }

}
