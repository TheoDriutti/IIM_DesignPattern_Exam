using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShield : MonoBehaviour
{
    [SerializeField] private Transform _owner;
    [SerializeField] private GameObject _shield;

    public void ToggleShield(bool value)
    {
        _shield.SetActive(value);

        _owner.GetComponent<PlayerEntity>()?.Health.SetShield(value);
        _owner.GetComponentInChildren<EntityFire>()?.SetShield(value);
    }
}