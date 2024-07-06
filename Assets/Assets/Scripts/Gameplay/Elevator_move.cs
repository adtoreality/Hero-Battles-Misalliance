using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator_move : MonoBehaviour
{
    //Variable pour le joueur 
    public GameObject player;
    //Rayon de detection du joueur dans l'ascenceur
    public float elevator_range = 5f;
    //Variable pour les bouton 
    public GameObject button;
    //Vitesse de l'ascensseur  
    public float elevatorSpeed = 1f;
    //Les étages 
    public Transform bracnh0;
    public Transform bracnh1;
    public Transform bracnh2;

    // Start is called before the first frame update
    void Start()
    {
        //On passe l'objet de tag player à la variable player 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Distance entre le joueur et l'ascensseur 
        float DistanceToElevator = Vector3.Distance(transform.position, player.transform.position);

        //Si la distance entre le joueur et l'ascenesseur est plus petit que je rayon de detetion du joueur dans l'ascensseur 
        if(DistanceToElevator <= elevator_range)
        {
            //On active les bouton 
            button.SetActive(true);
        }else
        {
            //On désactive les bouton
            button.SetActive(false);
        }
    }

    //Fonction pour faire monté l'ascensseur 
    public void ElavetorUp()
    {
        //transform.position = Vector3.up;
    }
    
    //Fonction pour faire descendre l'ascensseur 
    public void ElavetorDown()
    {
        //transform.position = Vector3.down;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 0f, 0f), elevator_range);
    }
}
