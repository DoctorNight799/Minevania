using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlatfromEnemy : MonoBehaviour
{
    public Transform platform; 
    private EnemyStats stats;

    int nextPoint = 0;
    float distToPoint;
    Rigidbody2D rb;
    
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, points(nextPoint));

        Vector2 movement = Vector2.MoveTowards(transform.position, points(nextPoint), stats.speed * Time.deltaTime);
        rb.MovePosition(movement);
        Debug.DrawLine(transform.position, points(nextPoint));

        if (distToPoint <= 0.01f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        transform.Rotate(0,0,-90);
        ChooseNextPoint();
    }

    void ChooseNextPoint()
    {
        nextPoint++;

        if(nextPoint == 4)
        {
            nextPoint = 0;
        }
    }

    Vector2 points(int num_point)
    {
        Vector2 point;
        switch(num_point){
            case 0:
                point = new Vector2(platform.position.x + platform.lossyScale.x / 2 + 0.76f, platform.position.y + platform.lossyScale.y / 2 + 0.76f);
                return point;
            case 1:
                point = new Vector2(platform.position.x + platform.lossyScale.x / 2 + 0.76f, platform.position.y - platform.lossyScale.y / 2 - 0.76f);
                return point;
            case 2:
                point = new Vector2(platform.position.x - platform.lossyScale.x / 2 - 0.76f, platform.position.y - platform.lossyScale.y / 2 - 0.76f);
                return point;
            case 3:
                point = new Vector2(platform.position.x - platform.lossyScale.x / 2 - 0.76f, platform.position.y + platform.lossyScale.y / 2 + 0.76f);
                return point;
        }
        Vector2 fake_point = new Vector2(0,0);
        return fake_point;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickaxe")
            Destroy(gameObject);
    }
}
