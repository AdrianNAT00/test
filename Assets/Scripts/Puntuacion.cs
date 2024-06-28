using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public int score = 0;
    public GameObject ball;

    // If the ball comes to into contact with the canasta, the score increases by 1 and destroys the ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
