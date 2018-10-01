using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararFlechas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);
        transform.Translate(Vector3.zero);
        if (collision.gameObject.tag != "Enemy")
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
        transform.Translate(Vector3.zero);
        if (other.gameObject.tag != "Enemy")
        {

        }
    }
}
