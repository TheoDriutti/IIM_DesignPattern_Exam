using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour, IInteractible
{
    [SerializeField] UnityEvent _onPickUp;
    [SerializeField] GameObject _gate;

    public event UnityAction OnPickUp
    {
        add => _onPickUp.AddListener(value);
        remove => _onPickUp.RemoveListener(value);
    }

    public bool TryPickUp()
    {
        _onPickUp.Invoke();

        Destroy(_gate);
        Destroy(transform.parent.gameObject);
        return true;
    }
}