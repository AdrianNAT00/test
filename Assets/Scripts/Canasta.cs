using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public float speed = 5f;
    public Renderer targetRenderer;


    // Start is called before the first frame update
    void Start()
    {
            if (MenuManager.instance != null)
            {
                targetRenderer.material.color = MenuManager.instance.colorToApply;
            }
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player from left to right
        float horizontal = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
