using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform camera_pos;
    public Transform min_pos, max_pos;
    Rigidbody2D rb;
    Vector2 camera_move, next;

    public float speed;
    public bool Battle_Horizontal, Battle_Vertical, Battle_All, Look;
    int vid_cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(Look){
            vid_cam = 0;
        }
        else if(Battle_All){
            vid_cam = 1;
        }
        else if(Battle_Horizontal){
            vid_cam = 2;
        }
        else if(Battle_Vertical){
            vid_cam = 3;
        }
    }

    void Update()
    {

    }
    
    void FixedUpdate()
	{
        switch(vid_cam){
            case 0: Look_function(); break;
            case 1: Battle_All_function(); break;
            case 2: Battle_Horizontal_function(); break;
            case 3: Battle_Vertical_function(); break;
        }
        rb.MovePosition(camera_move);
    }

    void Look_function(){
        next = new Vector2(camera_pos.position.x, camera_pos.position.y);
        camera_move = Vector2.MoveTowards(transform.position, next, speed * Time.fixedDeltaTime);
    }

    void Battle_All_function(){
        next = new Vector2(Mathf.Clamp(camera_pos.position.x, min_pos.position.x, max_pos.position.x), Mathf.Clamp(camera_pos.position.y, min_pos.position.y, max_pos.position.y));
        camera_move = Vector2.MoveTowards(transform.position, next, speed * Time.fixedDeltaTime);
    }

    void Battle_Horizontal_function(){
        next = new Vector2(Mathf.Clamp(camera_pos.position.x, min_pos.position.x, max_pos.position.x), transform.position.y);
        camera_move = Vector2.MoveTowards(transform.position, next, speed * Time.fixedDeltaTime);
    }

    void Battle_Vertical_function(){
        next = new Vector2(transform.position.x, Mathf.Clamp(camera_pos.position.y, min_pos.position.y, max_pos.position.y));
        camera_move = Vector2.MoveTowards(transform.position, next, speed * Time.fixedDeltaTime);
    }
}