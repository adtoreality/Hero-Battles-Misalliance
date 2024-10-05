using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] int playerLevel = 128;
    [SerializeField] Text playerLevelText;
    [SerializeField] int ennemyLevel = 128;
    [SerializeField] Text ennemyLevelText;
    [SerializeField] bool isStronger;
    [SerializeField] bool isReallyStronger;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("PlayerManager script game started");
        //playerLevelText.text = playerLevel.ToString();
        //Debug.Log(playerLevelText.text);
        //ennemyLevelText.text = ennemyLevel.ToString();
        //Debug.Log(ennemyLevelText.text);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("PlayerManager script game update");
    }

    public void startCombat()
    {
        if (isStronger)
        {
            //condition if player is really stronger than ennemy
            //play a really badass animation of player throwing enneny
            //condition to determine if player is armed
            //play specific animation depending on the player's weapon
              //if player has no weapon fists animation
              //if player has dagger, dagger animation
              //if player has sword, sword animation
              //if player has great sword, great sword animation
        }
        else
        {
            //play random animation from set of animations on being killed and dying
        }
    }

    // OnTriggerEnter est appelé quand le Collider other entre dans le déclencheur
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Just got triggered by " + other.gameObject.name);
        if(other.tag == "ennemy")
        {
            Debug.Log("Ennemy just entered trigger");
        }
    }

    // OnTriggerStay est appelé une fois par trame pour chaque Collider other qui touche le déclencheur
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stayig  in the trigger " + other.gameObject.name);
        if (other.tag == "ennemy")
        {
            //Debug.Log("Ennemy is among us");
            //stop running animation and face enemy
            StartCoroutine(LevelComparison());
        }
    }

    IEnumerator LevelComparison()
    {
        while(playerLevel>0 && ennemyLevel>0)
        {
            if(playerLevel>=ennemyLevel)
            {
                
                //ennemyLevel--;
                //ennemyLevelText.text = ennemyLevel.ToString();
                //playerLevel++;
                //playerLevelText.text = playerLevel.ToString();
                //yield return new WaitForSeconds(1.5f);
            }
            else
            {
                //playerLevel--;
                //playerLevelText.text = playerLevel.ToString();
                //ennemyLevel++;
                //ennemyLevelText.text = ennemyLevel.ToString();
                //yield return new WaitForSeconds(1.5f);
            }
        }
        
    }
    

}
