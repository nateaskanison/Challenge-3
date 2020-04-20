using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldSpeed : MonoBehaviour
{
    public float speed;
    private ParticleSystem ps;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        
        var main = ps.main;
        if (gameController.gameOver)
        {
            if (gameController.score >= 100)
            {
                main.simulationSpeed = speed * 10;
            }
            else
                main.simulationSpeed = 0;
        }
        
    }
}
