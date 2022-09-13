using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int hp = 100;
    public float speed = 10;
    public int mana = 50;
    public int money = 0;
    public int dmg = 25;

    void Update()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
        if(collision.gameObject.tag == "Enemy")
        {
            hp -= enemyStats.dmg;
        }
    }
}
