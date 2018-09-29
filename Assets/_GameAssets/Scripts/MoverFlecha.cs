using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFlecha : MonoBehaviour {

    [SerializeField] float velocidad = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
