using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public float eneMaxHP = 50;
    public float eneHP;
    public float attackTime;

    private float attackTimer = 0;
    private bool gameStart;

    DamageManager DamageManager;
    PlayerManager playerManager;
    StickerManager StickerManager;

    void Start()
    {
        try
        {
            DamageManager = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            playerManager = GameObject.Find("playerManager").GetComponent<PlayerManager>();
            StickerManager = GameObject.Find("StickerManager").GetComponent<StickerManager>();
            eneHP = eneMaxHP;
        }
        catch (System.NullReferenceException)
        {

        }
    }

    void Update()
    {

        if (gameStart)
        {
            Attack();
        }

        playerManager.EnemyHpGetter(eneHP);
    }

    void Attack()
    {

        this.attackTimer += Time.deltaTime;
        if (this.attackTimer >= attackTime)
        {
            this.attackTimer = 0;
            playerManager.Damage_GaugeReduction(10.0f);
            //Damage.Damages("Player", 10, pHP, pMaxHP);
            //Damage.Damages("Player");

            //print("プレイヤーHP： " + this.player.hp);
        }
    }

    public void GetBool(bool bo)
    {
        gameStart = bo;
    }

    public float MaxHpGetter()
    {
        return eneMaxHP;
    }

}