using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    //Diff�rent types d'arme 
    public bool sword_blue;
    public bool sword_red;
    public bool sword_lava;
    public bool golden_Sword;

    //Propri�t� des armes 
    public float damage;
    public GameObject effect;
    public float hitRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*C'est ici qu'il faut d�finir comment les attaques seront 
        effectuer en fonction de la distance avec les diff�rentes boites
        de collision avec des fonction � ^part si n�cessaire.*/
    }
}
