﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float enemyspeed;
    public float speed;
    private Rigidbody rb;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.forward * enemyspeed;
        rb.velocity = transform.forward * speed;
        HardMode();
    }
    private void HardMode()
    {
        if (gameController.hardMode)
        {
            enemyspeed = enemyspeed * 2;
            rb.velocity = transform.forward * speed;
            rb.velocity = transform.forward * enemyspeed;
        }
    }
}
