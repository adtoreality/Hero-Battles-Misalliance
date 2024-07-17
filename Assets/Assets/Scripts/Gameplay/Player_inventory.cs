using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_inventory : MonoBehaviour
{
    //Tableau pour les différentes armes 
    public GameObject[] weapons;

    //Distance pour ramasser une arme 
    public float pickUpRange = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        weapons[0] = GameObject.Find("Dagger_01");
    }

    // Update is called once per frame
    void Update()
    {
        //Ramasser une arme 
        //for(int i = 1; i < weapons.Length; i++)
        //{
        //    //Distance entre l'arme et le joueur 
        //    float Distance = Vector3.Distance(transform.position, weapons[i].transform.position);

        //    if (Distance <= pickUpRange)
        //    {
        //        weapons[0] = weapons[i];
        //    }
        //}
        //Equiper la nouvelle arme 
        //Deséquiper l'anciene arme 
    }

    //public void OnDrawGizmos()
    //{
    //    foreach (GameObject weapon in weapons)
    //    {
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawWireSphere(weapon.transform.position, pickUpRange);
    //    }
    //}
}
