using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour {
    
    [SerializeField] GameObject camara;
    [SerializeField] GameObject punto;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = camara.transform.rotation;
        this.transform.position = punto.transform.position;

    }
}
