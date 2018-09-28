using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour {
    
    [SerializeField] Camera camara;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation=new Quaternion(camara.transform.rotation.x, camara.transform.rotation.y, 0f,0f);
    }
}
