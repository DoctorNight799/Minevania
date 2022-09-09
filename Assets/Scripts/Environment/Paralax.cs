using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Camera cam;
    public Transform player;

    Vector2 start_pos;
    float start_z;

    Vector2 travel => (Vector2)cam.transform.position - start_pos;
    float distance_player => transform.position.z - player.position.z;
    float clipping_plane => (cam.transform.position.z + (distance_player > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float paralax_factor => Mathf.Abs(distance_player) / clipping_plane;


    void Start()
    {
        start_pos = transform.position;
        start_z = transform.position.z;
    }

    void Update()
    {
        Vector2 newPos = start_pos + travel * paralax_factor;
        transform.position = new Vector3(newPos.x, newPos.y, start_z);
    }
}
