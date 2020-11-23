using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip ButtonHover;
    public AudioClip ButtonPress;

    public void OnHover()
    {
        AudioHelper.PlayClip2D(ButtonHover, 1f);
    }

    public void OnPress()
    {
        AudioHelper.PlayClip2D(ButtonPress, 1f);
    }
}
