using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Vector3 local;

    private void Update()
    {
        local = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            Debug.Log("Hit Note");
            //Destroy(other.gameObject);

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            rb.AddForce(awayFromPlayer * 35, ForceMode.Impulse);
        }
    }
}
