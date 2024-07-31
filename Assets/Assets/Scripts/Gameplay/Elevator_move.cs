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

    //Sources et clip audio
    public AudioSource elevator_audioSource;
    public AudioSource button_audioSource;

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

            /* Rajouter le script de l'ouverture des portes pour que le joueur puisse passez
             et allez attaquer les ennemis présent sur cette étage puis refermer */
            //On verifie si l'ascenseur est encore au niveau du sol 
            if(Vector3.Distance(transform.position, points[0].position) < 0.01f)
            {
                //Le joueur ne peut pas traverser les portes de l'ascenseur 
                player.GetComponent<Player_move>().enabled = canMove;
            }else
            {
                //Le joueur peut traverser les portes de l'ascenseur 
                player.GetComponent<Player_move>().enabled = !canMove;
            }
        }

        //Si l'ascenseur est activé 
        if(canMove)
        {
            //On déplace l'ascenseur vers l'étage correspondant 
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, elevatorSpeed * Time.deltaTime);        
        }
    }

    //Fonction pour faire monté l'ascensseur 
    public void ElavetorUp()
    {
        //On lance le son du bouton 
        button_audioSource.Play();

        if (i == points.Length - 1)
        {
            Debug.Log("Limite supérieur.");
            return;
        }
        canMove = true;
        //On la le son de déplacement 
        elevator_audioSource.Play();
        //Le joueur ne peut pas se déplacer quand l'ascenceur est en mouvement  
        player.GetComponent<Player_move>().enabled = !canMove;
        i++;
    }
    
    //Fonction pour faire descendre l'ascensseur 
    public void ElavetorDown()
    {
        //On lance le son du bouton 
        button_audioSource.Play();

        if (i == 0)
        {
            Debug.Log("Limite inférieur.");
            return;
        }
        canMove = true;
        //On la le son de déplacement 
        elevator_audioSource.Play();
        //Le joueur ne peut pas se déplacer quand l'ascenceur est en mouvement  
        player.GetComponent<Player_move>().enabled = !canMove;
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
