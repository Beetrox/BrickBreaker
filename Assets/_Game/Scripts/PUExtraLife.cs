using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : PowerUpProperties
{
    LivesController livesController;

    protected override void ExecutePowerUp()
    {
        GameObject lives = GameObject.FindGameObjectWithTag("Lives");
        livesController = lives.GetComponent<LivesController>();

        livesController.AddLife();
        Destroy(gameObject);
    }
}
