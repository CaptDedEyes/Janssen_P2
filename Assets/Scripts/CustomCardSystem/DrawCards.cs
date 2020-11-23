using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject PlayerArea;
    public GameObject EnemyArea;

    public AudioClip firstDrawSound;

    public List<GameObject> cards = new List<GameObject>();

    public void FirstDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0,cards.Count)], 
                new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.gameObject.tag = "Player";
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], 
                new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.gameObject.tag = "Enemy";
            enemyCard.transform.SetParent(EnemyArea.transform, false);
            enemyCard.GetComponent<CardFlipper>().Flip();
        }
        AudioHelper.PlayClip2D(firstDrawSound, 1f);
    }

    public void NextDraw()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)],
                new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.gameObject.tag = "Player";
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)],
                new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.gameObject.tag = "Enemy";
            enemyCard.transform.SetParent(EnemyArea.transform, false);
            enemyCard.GetComponent<CardFlipper>().Flip();
        }
    }
}
