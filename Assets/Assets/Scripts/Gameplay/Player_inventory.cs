using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_inventory : MonoBehaviour
{
    //Ajouter les variable relative aux information du joueur

    //Tableau pour les différentes armes 
    public static GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        //Taille du tableau d'arme 
        weapons = new GameObject[3];
        //initialisation de l'arme principal
        weapons[0] = GameObject.FindGameObjectWithTag("Dagger_01");
    }

    // Update is called once per frame
    void Update()
    {
        //Ramasser une arme 
        //Equiper la nouvelle arme 
        //Deséquiper l'anciene arme 
    }
}
