using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracion : MonoBehaviour {

    
    //Botones
    public static string botonDisparo = "Fire1";
    public static KeyCode botonArma1=KeyCode.Alpha1;
    public static KeyCode botonArma2 = KeyCode.Alpha2;
    public static KeyCode botonZoom = KeyCode.Mouse3;

    //capas
    public static string tagEntorno = "Enviroment";
    public static string tagMunicion = "Ammo";
    public static string tagEnemigos = "Enemy";
    public static string tagPlayer = "Player";


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
