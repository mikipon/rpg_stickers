using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    //PlayerManager _PlayerManager;
    //EnemiesManager _EnemiesManager;

    private void Start()
    {

        Debug.Log("Damage");

        //try
        //{
        //    _PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        //    _EnemiesManager = GameObject.Find("EnemiesManager").GetComponent<EnemiesManager>();
        //}
        //catch (System.NullReferenceException)
        //{

        //}
    }
    private void Update()
    {
        
    }


    //public void Damages(string name, float power, float hp, float maxHp)
    //{
    //    Debug.Log("Damage入った");
    //    //hp -= power;

    //    if (name == "Player")
    //    {
    //        Debug.Log("Hey");
    //        Debug.Log(name + "HP : " + hp);
    //        _PlayerManager.GaugeReduction(power);
    //        hp -= power;
    //        //Debug.Log(name + "HP : " + hp);

    //        //回復薬を落とす
    //        if (hp < maxHp)
    //        {
    //            Debug.Log("はいったぞ");
    //            _PlayerManager.wantRecovery = true;
    //        }

    //    }
    //    else if (name == "Enemy")
    //    {
    //        //hp = _EnemiesManager.eneHP;
    //        //maxHp = _EnemiesManager.eneMaxHP;
    //        //Debug.Log(name + "HP : " + hp);
    //        //hp -= power;

    //    }

    //    //mouseClick = true;
    //}

    public void Damages()
    {
        Debug.Log("Helllo");
    }
}
