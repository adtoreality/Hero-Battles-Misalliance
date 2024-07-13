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
    //pour remplacer le le num�ro du bouton gauche de la souris
    const int LEFT_MOUSE_BOTTON = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //Au lancement la cible est la position du joueur (Pour qu'il soit sur place)
        targetPosition = transform.position;
        //Au lancement le joueur ne ce d�place pas 
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //On v�rifie si on � cliqu� 
        if(Input.GetMouseButtonDown(LEFT_MOUSE_BOTTON))
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
            targetPosition = ray.GetPoint(point);

            //Le jouer ce d�place
            isMoving = true;
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
        //transform.LookAt(targetPosition);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Si le personnage est arriv� � destination 
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }

        //On dessine le raycast dans la sc�ne 
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }
}
