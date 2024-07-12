using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] int playerLevel = 127;
    [SerializeField] Text playerLevelText;
    [SerializeField] int ennemyLevel = 126;
    [SerializeField] Text ennemyLevelText;
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

    // OnTriggerEnter est appel� quand le Collider other entre dans le d�clencheur
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Just got triggered by " + other.gameObject.name);
        if(other.tag == "ennemy")
        {
            Debug.Log("Ennemy just entered trigger");
        }
    }

    // OnTriggerStay est appel� une fois par trame pour chaque Collider other qui touche le d�clencheur
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stayig  in the trigger " + other.gameObject.name);
        if (other.tag == "ennemy")
        {
            //Debug.Log("Ennemy is among us");
            StartCoroutine(LevelComparison());
        }
    }

    IEnumerator LevelComparison()
    {
        while(playerLevel>0 && ennemyLevel>0)
        {
            if(playerLevel>=ennemyLevel)
            {
                ennemyLevel--;
                ennemyLevelText.text = ennemyLevel.ToString();
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                playerLevel--;
                playerLevelText.text = playerLevel.ToString();
                yield return new WaitForSeconds(1.5f);
            }
        }
        
    }
    

}
