using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracion : MonoBehaviour {

    
    //Botones
    public static string botonDisparo = "Fire1";
    public static KeyCode botonArma1=KeyCode.Alpha1;
    public static KeyCode botonArma2 = KeyCode.Alpha2;
    public static string botonZoom = "Fire2";

    //capas
    public static string tagEntorno = "Enviroment";
    public static string tagMunicion = "Ammo";
    public static string tagEnemigos = "Enemy";
    public static string tagPlayer = "Player";
    //juego
        //entre un valor de 1 a 10 a partir de ese valor
    public static int[] lvl1 = new int[] { 7, 9, 10 };
    public static int[] lvl2 = new int[] { 6, 9, 10 };
    public static int[] lvl3 = new int[] { 4, 8, 10 };
        //incremento de tiempo ej 10,20,30
    public static int[] TiemposLvl = new int[] { 1, 2, 3 };
    public static int MultiplicadorLvl = 10;
    //player
    public static float FovPlayer=60;
    public static float FovZoom = 20;
}
