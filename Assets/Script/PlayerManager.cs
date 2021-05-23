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

    void Start()
    {
        _hp = 100;
        _maxHp = 100;
        Debug.Log("HP : " + _hp);
    }

    void Update()
    {

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
        float valueFrom = _hp / _maxHp;
        float valueTo = (_hp - reducationValue) / _maxHp;

        //緑のゲージ減少
        GreenGauge.fillAmount= valueTo;
        Debug.Log(GreenGauge.fillAmount);

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
