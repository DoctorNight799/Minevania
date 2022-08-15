using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 2f;
    void Update()
    {
        if (time != 0)
            time -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
