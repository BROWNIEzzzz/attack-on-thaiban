using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
    public float DelayDestroy = 4f;
    private float startTime;
    public GameObject explode;
    GameController gameController;
    void Start()
    {
        startTime = Time.time;
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Speed * this.gameObject.transform.forward;
        if (Time.time - startTime >= DelayDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
            Instantiate(explode, transform.position, transform.rotation);
            gameController.getScore();
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            gameController.getDamage();
        }
    }
}
