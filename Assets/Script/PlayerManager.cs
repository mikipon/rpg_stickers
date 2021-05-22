using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject clickGameObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickGameObject.tag.ToString());

            if (clickGameObject.tag == "sticker")
            {
                Debug.Log("その他のステッカー、何もなし");
            }
            else if (clickGameObject.tag == "weapon")
            {
                Debug.Log("武器ステッカー、攻撃");
            }
        }    
    }
}
