using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    //Vitesse du personnage 
    public float speed = 1f;
    //Position de la cible 
    public Vector3 targetPosition;
    //Variable pour savoir si le perso ce déplace 
    bool isMoving;
    //Variable pour savoir si le perso valider une destination
    bool canClick;
    //pour remplacer le le numéro du bouton gauche de la souris
    const int LEFT_MOUSE_BOTTON = 0; 
    //Variable de l'animator du joueur
    private Animator animator;
    //Marquer pour l'emplacement de destination 
    public GameObject marquer;

    //Source et clip audio 
    public AudioSource player_audioSource;
    public AudioClip running;

    // Start is called before the first frame update
    void Start()
    {
        //On assigne les components 
        animator = gameObject.GetComponent<Animator>();
        player_audioSource = gameObject.GetComponent<AudioSource>();
        //Au lancement la cible est la position du joueur (Pour qu'il soit sur place)
        targetPosition = transform.position;
        //Au lancement le joueur ne ce déplace pas 
        isMoving = false;
        //Au lancement le joueur peut clicker 
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        //On vérifie si on à cliqué 
        if(Input.GetMouseButtonDown(LEFT_MOUSE_BOTTON) && canClick)
        {
            SetTargetPosition();
        }

        //Si le joueur est en deplacement 
        if(isMoving)
        {
            MovePlayer();
        }
    }

    //Fonction qui va définir le point qui vas servir de cible
    void SetTargetPosition()
    {
        //Création du point d'arriver avec un plane 
        Plane plane = new Plane(Vector3.up, transform.position);
        //Création d'un raycast qui récupère la position de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f; 

        //
        if(plane.Raycast(ray, out point))
        {
            //Assignation de l'objectif vers lequel on se déplace
            targetPosition = ray.GetPoint(point);
            //Positionnement du marqueur
            marquer.transform.position = new Vector3(targetPosition.x, marquer.transform.position.y, marquer.transform.position.z);
            //Le jouer ce déplace
            isMoving = true;
            //Le joueur ne peut pas changer de destination pendant qu'il se déplace
            canClick = false;
            animator.SetBool("isRunning", isMoving);
            //On lance le son de la course 
            player_audioSource.PlayOneShot(running);
        }
    }

    //Fonction pour le déplacement du jouer 
    void MovePlayer()
    {
        //Le joueur regarde dans la direction qui lui est indiqué 
        /*comparé les position en x*/ 
        if(targetPosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (targetPosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        //On déplace le joueur dans le plan 
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Si le personnage est arrivé à destination 
        if(transform.position.x == targetPosition.x)
        {
            isMoving = false;
            canClick = true;
            animator.SetBool("isRunning", isMoving);
            //On coupe le son de la course 
            player_audioSource.Stop();
        }

        //On dessine le raycast dans la scène 
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }
}
