using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        if(tag == "Player")
        {
            zoomCard = Instantiate(gameObject,
            new Vector2(Input.mousePosition.x, Input.mousePosition.y + 125), Quaternion.identity);

            zoomCard.transform.SetParent(Canvas.transform, false);
            zoomCard.layer = LayerMask.NameToLayer("Zoom");

            RectTransform rect = zoomCard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(150, 200);
        }

        if (tag == "Enemy")
        {
            zoomCard = Instantiate(gameObject,
            new Vector2(Input.mousePosition.x, Input.mousePosition.y - 125), Quaternion.identity);

            zoomCard.transform.SetParent(Canvas.transform, false);
            zoomCard.layer = LayerMask.NameToLayer("Zoom");

            RectTransform rect = zoomCard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(150, 200);
        }
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}
