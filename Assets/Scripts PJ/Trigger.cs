using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float clickRate = 0.4f;
    public float netClick = 0f;
    private GameController gameController;

    private void Start()
    {
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<GameController>();
        }
    }

    void update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)&& Time.time > netClick)
        {
            netClick = Time.time + clickRate;
            gameController.getTriggerstart();
        }
    }
}
