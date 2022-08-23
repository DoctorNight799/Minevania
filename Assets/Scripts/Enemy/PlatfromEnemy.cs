using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Transform platform; 

    int nextPoint = 0;
    float distToPoint;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, points(nextPoint));

        Vector2 movement = Vector2.MoveTowards(transform.position, points(nextPoint), moveSpeed * Time.deltaTime);
        rb.MovePosition(movement);

        if (distToPoint <= 0)
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
                point = new Vector2(platform.position.x + platform.lossyScale.x / 2, platform.position.y + platform.lossyScale.y / 2);
                return point;
            case 1:
                point = new Vector2(platform.position.x + platform.lossyScale.x / 2, platform.position.y - platform.lossyScale.y / 2);
                return point;
            case 2:
                point = new Vector2(platform.position.x - platform.lossyScale.x / 2, platform.position.y - platform.lossyScale.y / 2);
                return point;
            case 3:
                point = new Vector2(platform.position.x - platform.lossyScale.x / 2, platform.position.y + platform.lossyScale.y / 2);
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
