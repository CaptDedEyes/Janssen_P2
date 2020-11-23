using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public AreaHealth playerArea;
    public AreaHealth enemyArea;
    public GameObject dropZone;
    public GameObject ConfirmButton;
    public bool playersTurn = false;
    public AudioClip discardSound;

    private void Update()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (dropZone.transform.GetChild(i).gameObject.activeInHierarchy == true
                && playersTurn == true)
            {
                ConfirmButton.gameObject.SetActive(true);
            }
            else if(playersTurn == false)
            {
                ConfirmButton.gameObject.SetActive(false);
            }
        }
    }

    public void Discard()
    {
        ConfirmButton.gameObject.SetActive(false);

        Transform playedCard = dropZone.transform.GetChild(0);
        CardValue cardValue = playedCard.GetComponent<CardValue>();
        int damage = cardValue.amount;

        if (playedCard.tag == "Player")
        {
            enemyArea.DecreaseHealth(damage);
            Debug.Log("Enemy took " + damage + " damage!");

            Destroy(playedCard.gameObject);
        }
        else if (playedCard.tag == "Enemy")
        {
            playerArea.DecreaseHealth(damage);
            Debug.Log("Player took " + damage + " damage!");

            Destroy(playedCard.gameObject);
        }
        else
        {
            Debug.Log("No cards detected in the Drop Zone");
        }
        AudioHelper.PlayClip2D(discardSound, 1f);
    }
}
