using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject[] points;

    int nextPoint = 1;
    float distToPoint;
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, points[nextPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, points[nextPoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += points[nextPoint].transform.position.z;
        transform.eulerAngles = currRot;
        ChooseNextPoint();
    }

    void ChooseNextPoint()
    {
        nextPoint++;

        if(nextPoint == points.Length)
        {
            nextPoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickaxe")
            Destroy(gameObject);
    }
}
