using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool mouseClick = true;

    private float _hp;
    private float _maxHp;

    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;

    GameObject clickGameObject;
    StickerManager StickerManager;

    void Start()
    {
        _hp = 100;
        _maxHp = 100;
        Debug.Log("HP : " + _hp);
    }

    void Update()
    {
        try {
            StickerManager = GameObject.Find("StickerManager").GetComponent<StickerManager>();
        }
        catch (System.NullReferenceException)
        {

        }
    }

    public void Damage(float power)
    {
        GaugeReduction(power);
        _hp -= power;
        Debug.Log("HP : " + _hp);
        //mouseClick = true;
    }

    private void GaugeReduction(float reducationValue, float time = 1f)
    {
        /*始まると同時に体力が増えるモーションをつけたい*/
        //GreenGauge.fillAmount = 0;

        //if (StickerManager.gameStart)
        //{
        //    for (float i = 0.1f; i<1; i+=0.1f)
        //    {
        //        GreenGauge.fillAmount = i;
        //    }
        //}

        Debug.Log(reducationValue);
        float valueFrom = _hp / _maxHp;
        float valueTo = (_hp - reducationValue) / _maxHp;
        Debug.Log(valueTo);
        //緑のゲージ減少
        GreenGauge.fillAmount = valueTo;
        //GreenGauge.fillAmount = valueFrom;


        //GreenGauge.fillAmount = valueFrom;


        //yield return new WaitForSeconds(time);
        //RedGauge.fillAmount = valueTo;
        //if (RedGauge.fillAmount == 0)
        //{
        //    Debug.Log("Die");
        //}
    }


    public GameObject MouseClick()
    {
        if (Input.GetMouseButtonDown(0) && mouseClick)
            //Debug.Log("Click");
        {
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

}
