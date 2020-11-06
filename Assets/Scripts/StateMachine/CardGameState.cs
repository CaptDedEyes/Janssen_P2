using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardGameSM))]
public class CardGameState : State
{
    protected CardGameSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<CardGameSM>();
    }
}
