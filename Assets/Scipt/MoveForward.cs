using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;
    private float speed = 5;
    
    public float backBound = 15;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        rb.AddForce(Vector3.right * speed * Time.deltaTime);
        
        if (transform.position.x > backBound)
        {
            Destroy(gameObject);
        }

        if (gameManager.isGameActive == false)
        {
            Destroy(gameObject);
        }
    }

}
