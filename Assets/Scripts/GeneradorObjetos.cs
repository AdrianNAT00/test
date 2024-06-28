using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : ObjectMovement
{
    public GameObject prefabBall;
    Vector3 position;
    public GameObject canasta;
    public float speed = 5;
    void Start()
    {
        //Instantiate a ball every 3 seconds
        InvokeRepeating("GenerateBall", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void GenerateBall()
    {
        //Instantiate a ball above the canasta
        position = new Vector3(Random.Range(-50, 51), canasta.transform.position.y + 20, canasta.transform.position.z);
        Instantiate(prefabBall, position, Quaternion.identity);
    }

    public override void Move()
    {
        //Move the generated ball down
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            ball.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
