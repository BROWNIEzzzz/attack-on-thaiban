using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaGameObject : MonoBehaviour
{
    public float DelayDestroy = 1f;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= DelayDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
