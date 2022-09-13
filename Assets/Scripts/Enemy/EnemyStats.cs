using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int hp = 100;
    public float speed;
    public int money;
    public int dmg;

    public GameObject player;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
            playerStats.money += money;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Pickaxe")
        {
            hp -= playerStats.dmg;
        }
    }
}
