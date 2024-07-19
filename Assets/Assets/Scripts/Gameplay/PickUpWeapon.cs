using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    //Reférence au joueur 
    public Transform player;
    public Transform player_hand;

    //Numéro d'orde des armes 
    int mainWeapon = 0;
    int secondaryWeapon = 1;
    int temp = 2;

    //Distance pour ramasser une arme 
    public float pickUpRange = 0.18f;

    // Start is called before the first frame update
    void Start()
    {
        //On passe le joueur dans la variable 
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Tableau des armes présent au terrain 
        GameObject[] allWeapon = GameObject.FindGameObjectsWithTag("weapon");

        foreach (var weapon in allWeapon)
        {
            //Distance entre l'arme et le joueur 
            float Distance = Vector3.Distance(weapon.transform.position, player.position);

            //Ramasse de l'arme si le joueur est à la bonne distance 
            if (Distance <= pickUpRange)
            {
                //L'arme secondaire est définit comme celle qu'on veut ramasser 
                Player_inventory.weapons[secondaryWeapon] = weapon;

                MainWeaponChange();
            }
        }
    }

    //Fonction pour le changment d'arme
    void MainWeaponChange()
    {
        //L'arme deviens enfant de la main 
        Player_inventory.weapons[secondaryWeapon].transform.SetParent(transform);
        //Changement de position et de rotation
        Player_inventory.weapons[secondaryWeapon].transform.position = Player_inventory.weapons[mainWeapon].transform.position;
        Player_inventory.weapons[secondaryWeapon].transform.rotation = Player_inventory.weapons[mainWeapon].transform.rotation;

        //Changement d'ordre 
        Player_inventory.weapons[temp] = Player_inventory.weapons[mainWeapon];
        Player_inventory.weapons[mainWeapon] = Player_inventory.weapons[secondaryWeapon];
        Player_inventory.weapons[secondaryWeapon] = Player_inventory.weapons[temp];

        //Suppression de l'ancienne arme 
        Destroy(Player_inventory.weapons[secondaryWeapon]);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, pickUpRange);
    }
}
