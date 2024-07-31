using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    //Vitesse du personnage 
    public float speed = 1f;
    //Position de la cible 
    public Vector3 targetPosition;
    //Variable pour savoir si le perso ce d�place 
    bool isMoving;
    //Variable pour savoir si le perso valider une destination
    bool canClick;
    //pour remplacer le le num�ro du bouton gauche de la souris
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
        //Au lancement le joueur ne ce d�place pas 
        isMoving = false;
        //Au lancement le joueur peut clicker 
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        //On v�rifie si on � cliqu� 
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

    //Fonction qui va d�finir le point qui vas servir de cible
    void SetTargetPosition()
    {
        //Cr�ation du point d'arriver avec un plane 
        Plane plane = new Plane(Vector3.up, transform.position);
        //Cr�ation d'un raycast qui r�cup�re la position de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f; 

        //
        if(plane.Raycast(ray, out point))
        {
            //Assignation de l'objectif vers lequel on se d�place
            targetPosition = ray.GetPoint(point);
            //Positionnement du marqueur
            marquer.transform.position = new Vector3(targetPosition.x, marquer.transform.position.y, marquer.transform.position.z);
            //Le jouer ce d�place
            isMoving = true;
            //Le joueur ne peut pas changer de destination pendant qu'il se d�place
            canClick = false;
            animator.SetBool("isRunning", isMoving);
            //On lance le son de la course 
            player_audioSource.PlayOneShot(running);
        }
    }

    //Fonction pour le d�placement du jouer 
    void MovePlayer()
    {
        //Le joueur regarde dans la direction qui lui est indiqu� 
        /*compar� les position en x*/ 
        if(targetPosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (targetPosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        //On d�place le joueur dans le plan 
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Si le personnage est arriv� � destination 
        if(transform.position.x == targetPosition.x)
        {
            isMoving = false;
            canClick = true;
            animator.SetBool("isRunning", isMoving);
            //On coupe le son de la course 
            player_audioSource.Stop();
        }

        //On dessine le raycast dans la sc�ne 
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }
}
