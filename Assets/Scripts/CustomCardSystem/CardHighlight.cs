using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHighlight : MonoBehaviour
{
    public GameObject highlight;
    public AudioClip selectSound;

    private void Awake()
    {
        highlight.SetActive(false);
    }

    public void OnHoverEnter()
    {
        highlight.SetActive(true);
        AudioHelper.PlayClip2D(selectSound, 1f);
    }

    public void OnHoverExit()
    {
        highlight.SetActive(false);
    }
}
