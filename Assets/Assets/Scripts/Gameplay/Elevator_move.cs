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
    //Les étages 
    public Transform bracnh0;
    public Transform bracnh1;
    public Transform bracnh2;

    // Mouvement de l'ascenseur 
    public bool canMove;
    //Vitesse de l'ascensseur  
    public float elevatorSpeed = 1f;
    //Premier étage
    public int startPoint = 0;
    //Tableau des etages de l'ascenseur 
    public Transform[] points;

    int i;
    /*bool reverse;*/

    // Start is called before the first frame update
    void Start()
    {
        //On passe l'objet de tag player à la variable player 
        player = GameObject.FindGameObjectWithTag("Player");
        //On initialise la position de l'ascenseur 
        transform.position = points[startPoint].position;
        i = startPoint;
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

        //Conditon de déplacement de l'ascenseur 
        if(Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            //L'ascenseur s'arrête 
            canMove = false;
        }

        //Si l'ascenseur est activé 
        if(canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, elevatorSpeed * Time.deltaTime);        
        }
    }

    //Fonction pour faire monté l'ascensseur 
    public void ElavetorUp()
    {
        if (i == points.Length - 1)
        {
            Debug.Log("Limite supérieur.");
            return;
        }
        canMove = true;
        i++;
    }
    
    //Fonction pour faire descendre l'ascensseur 
    public void ElavetorDown()
    {
        if (i == 0)
        {
            Debug.Log("Limite inférieur.");
            return;
        }
        canMove = true;
        i--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            //Le joueur devient enfant de l'ascenseur 
            Debug.Log("Ok!");
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //Le joueur n'est plus enfant de l'ascenseur 
            Debug.Log("Pas Ok!");
            collision.transform.SetParent(transform);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 0f, 0f), elevator_range);
    }
}
