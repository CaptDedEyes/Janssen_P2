using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;
    public GameObject dropZone;
    public DropZone _dropZone;
    public GameObject EnemyArea;
    public GameObject playerCover;
    public AudioClip endDragSound;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();
        playerCover.gameObject.SetActive(true);

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        int rand = UnityEngine.Random.Range(0, 2);
        Transform randomCard = EnemyArea.transform.GetChild(rand);
        randomCard.transform.SetParent(dropZone.transform, false);
        AudioHelper.PlayClip2D(endDragSound, 1f);

        Debug.Log("Enemy performs action");
        yield return new WaitForSeconds(pauseDuration);

        _dropZone.Discard();
        EnemyTurnEnded?.Invoke();
        playerCover.gameObject.SetActive(false);

        //turn over. Go back to Player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }

    public void EnemyWins()
    {
        EnemyTurnEnded?.Invoke();
        StateMachine.ChangeState<EnemyWinCardGameState>();
        Debug.Log("Enemy wins!");
    }
}