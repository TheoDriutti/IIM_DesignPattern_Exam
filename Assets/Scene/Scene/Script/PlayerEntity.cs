using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;

    public Health Health => _health;

    private void Awake()
    {
        _health.OnDeath += () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


