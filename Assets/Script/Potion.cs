using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour, IInteractible
{
    [SerializeField] UnityEvent _onPickUp;
    [SerializeField] int _healValue;

    private Health _player;

    public event UnityAction OnPickUp
    {
        add => _onPickUp.AddListener(value);
        remove => _onPickUp.RemoveListener(value);
    }

    void Start()
    {
        _player = FindObjectOfType<PlayerEntity>().GetComponent<Health>();
    }

    public bool TryPickUp()
    {
        _onPickUp.Invoke();

        _player?.Heal(_healValue);

        Destroy(gameObject);
        return true;
    }
}