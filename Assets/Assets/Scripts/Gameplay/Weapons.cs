using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    //Différent types d'arme 
    public bool sword_blue;
    public bool sword_red;
    public bool sword_lava;
    public bool golden_Sword;

    //Propriété des armes 
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
        /*C'est ici qu'il faut définir comment les attaques seront 
        effectuer en fonction de la distance avec les différentes boites
        de collision avec des fonction à ^part si nécessaire.*/
    }
}
