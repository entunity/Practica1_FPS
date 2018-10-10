using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField] Transform Enemigo;
    [SerializeField] float TiempoSpawn;

    private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= TiempoSpawn) {
            Instantiate(Enemigo.gameObject,this.transform.position, this.transform.rotation);
            timer = 0;
        }
	}
}
