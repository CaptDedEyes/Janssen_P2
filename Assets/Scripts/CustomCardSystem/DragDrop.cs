using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDragging = false;
    private bool isOverDropZone = false;

    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    [Header("SFX")]
    public AudioClip startDragSound;
    public AudioClip endDragSound;

    private int maxChildren = 1;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    void Update()
    {
        if(isDragging == true)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        if(tag == "Player")
        {
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
            AudioHelper.PlayClip2D(startDragSound, 1f);
        }
    }

    public void EndDrag()
    {
        if(tag == "Player")
        {
            isDragging = false;
            if (isOverDropZone == true && dropZone.transform.childCount < maxChildren)
            {
                transform.SetParent(dropZone.transform, false);
            }
            else
            {
                transform.position = startPosition;
                transform.SetParent(startParent.transform, false);
            }
            AudioHelper.PlayClip2D(endDragSound, 1f);
        }
    }
}
