using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private Transform playerPos;
    private Vector2 currentPos;
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
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
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
                //anim
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickaxe")
            Destroy(gameObject);
    }
}
