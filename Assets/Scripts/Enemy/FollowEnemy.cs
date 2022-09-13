using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    private Transform playerPos;
    private Vector2 currentPos;
    private EnemyStats stats;
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, stats.speed * Time.deltaTime);
            //anim
        }
        else
        {
            if(Vector2.Distance(transform.position, currentPos) <= 0)
            {
                //anim
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, stats.speed * Time.deltaTime);
                //anim
            }
        }
    }
}
