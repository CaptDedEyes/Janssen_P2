using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaHealth : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] int _maxHealth = 30;
    [SerializeField] Slider _slider;
    [SerializeField] GameObject objArea;
    [SerializeField] GameObject dropZone;
    [SerializeField] GameOver _gameOver;
    int _currentHealth;

    [Header("SFX")]
    [SerializeField] AudioClip[] _playerDamageSound;
    [SerializeField] AudioClip[] _enemyDamageSound;

    private void Start()
    {
        _slider.maxValue = _maxHealth;
        _slider.value = _currentHealth;
        _currentHealth = _maxHealth;
    }


    private void Update()
    {
        _slider.value = _currentHealth;
    }

    public void DecreaseHealth (int damage)
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= damage;

            if (objArea.tag == "Player")
            {
                AudioHelper.PlayClip2D(_playerDamageSound[Random.Range(0,2)], 1f);
            }
            if (objArea.tag == "Enemy")
            {
                AudioHelper.PlayClip2D(_enemyDamageSound[Random.Range(0,1)], 1f);
            }
        }
        if(_currentHealth <=0)
        {
            Kill();
        }
    }

    public void Kill ()
    {
        if (objArea.tag == "Player")
        {
            _gameOver.EnemyWins();
        }
        if (objArea.tag == "Enemy")
        {
            _gameOver.PlayerWins();
        }
        Destroy(objArea);
        Destroy(dropZone);
    }
}
