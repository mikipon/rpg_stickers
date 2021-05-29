using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //public bool mouseClick = true;
    public bool wantRecovery = false;

    public float maxHp = 100;
    public float hp;

    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;
    private bool gameStart;
    private float eneHp;
    private float eneMaxHp;

    GameObject clickGameObject;
    DamageManager DamageManager;
    StickerManager StickerManager;

    public GameObject MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            clickGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickGameObject = hit2d.transform.gameObject;
                //Debug.Log(clickGameObject.tag.ToString());
            }
        }

        return clickGameObject;
    }

    public float HpGetter()
    {
        return hp;
    }

    public float MaxHpGetter()
    {
        return maxHp;
    }

    void Start()
    {
        maxHp = hp;
        try
        {
            DamageManager = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            StickerManager = GameObject.Find("StickerManager").GetComponent<StickerManager>();
        }
        catch (System.NullReferenceException)
        {

        }

    }

    void Update()
    {

        

        if (gameStart)
        {
            try
            {
                GameObject clickSticker = MouseClick();
                Attack(10);
                //Debug.Log(_stickerObject.name.ToString());
                Sorting(clickSticker);

            }
            catch (System.NullReferenceException) // why null??
            {
                Debug.Log("NullReferenceException");
            }

            if (hp < 90)
            {
                //wantRecovery = false; // 薬が欲しい
            }

        }
        else
        {

        }
    }

    public void GetBool(bool bo)
    {
        gameStart = bo;
    }

    public void EnemyHpGetter(float hp)
    {
        eneHp = hp;
    }

    /// <summary>
    /// ダメージの表示
    /// </summary>
    /// <param name="reducationValue"></param>
    /// <param name="time"></param>
    public void Damage_GaugeReduction(float reducationValue, float time = 1f)
    {

        Debug.Log(reducationValue);
        float valueFrom = hp / maxHp;
        float valueTo = (hp - reducationValue) / maxHp;
        Debug.Log(valueTo);
        //緑のゲージ減少
        GreenGauge.fillAmount = valueTo;

    }

    /// <summary>
    /// 回復の表示
    /// </summary>
    /// <param name="reducationValue"></param>
    /// <param name="time"></param>
    /// <param name="click"></param>
    public void Recovery_GaugeReduction(float reducationValue,　bool click, float time = 1f)
    { 
        
    }

    /// <summary>
    /// クリックした者を選別する
    /// </summary>
    /// <param name="gameObject"></param>
    void Sorting(GameObject gameObject)
    {
        if (gameObject.tag == "sticker")
        {
            Debug.Log("その他のステッカー、何もなし");
            ClickOther(gameObject);
        }
        else if (gameObject.tag == "weapon")
        {
            Debug.Log("武器ステッカー、攻撃");
            //ClickWeaponAttack(_stickerObject);
            ClickWeapon(gameObject);
        }
        else if (gameObject.tag == "recovery")
        {
            Debug.Log("薬薬くすり");
            bool click = ClickRecovery();
            Recovery_GaugeReduction(10, click);

        }
        else
        {
            Debug.Log("null");
        }
    }

    /// <summary>
    /// プレイヤーがクリックした武器以外Sticker
    /// </summary>
    /// <param name="gameObject"></param>
    void ClickOther(GameObject gameObject)
    {

    }

    /// <summary>
    /// プレイヤーがクリックした薬Sticker
    /// </summary>
    /// <param name="gameObject"></param>
    public bool ClickRecovery()
    {
        bool clickRecov = true;
        return clickRecov;
    }

    /// <summary>
    /// プレイヤーがクリックした武器Sticker
    /// </summary>
    /// <param name="gameObject"></param>
    void ClickWeapon(GameObject gameObject)
    {

        Debug.Log(gameObject.name.ToString());

        if (gameObject.name == "Arrow(Clone)")
        {
            Debug.Log("Arrow");
            //_playerManager.mouseClick = false;
            StickerManager.Display(gameObject);
            Attack(10);
            //_playerManager.mouseClick = true;
        }
        else if (gameObject.name == "Axe(Clone)")
        {
            Debug.Log("Axe");
            //_playerManager.mouseClick = false;
            StickerManager.Display(gameObject);
            //_playerManager.mouseClick = true;
        }
        else if (gameObject.name == "Cannon(Clone)")
        {
            Debug.Log("Cannon");
            //_playerManager.mouseClick = false;
            StickerManager.Display(gameObject);
            //_playerManager.mouseClick = true;
        }
        else if (gameObject.name == "Gun(Clone)")
        {
            Debug.Log("Gun");
            ////_playerManager.mouseClick = false;
            StickerManager.Display(gameObject);
            //_playerManager.mouseClick = true;
        }
        else if (gameObject.name == "JapaneseSword(Clone)")
        {
            Debug.Log("JapaneseSword");
            //_playerManager.mouseClick = false;
            StickerManager.Display(gameObject);
            //_playerManager.mouseClick = true;
        }
        else if (gameObject.name == gameObject.name)
        {
            Debug.Log("一緒");
        }
    }

    void Attack(float power)
    {
        Debug.Log("Attak()");
        eneHp -= power;
        //Debug.Log("Enemy HP : " + eneHp);
        
    }

}
