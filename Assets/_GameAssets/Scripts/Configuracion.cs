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
    //juego
    public static string nombreParticulas = "ExplosionEnemigoParticulas";

    //player
    public static float vida=100;
    public static float DanioPlayer=0;
    public enum enumArmas:int {
        ballesta = 0,
        lanzallamas = 1

    }
}
