using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderManager : MonoBehaviour
{
    [SerializeField] Health _playerHealthReference;

    private Slider slider;

    void Awake()
    {
        _playerHealthReference.OnHeal += UpdateSlider;
        _playerHealthReference.OnDamage += UpdateSlider;

        slider = GetComponent<Slider>();
    }

    void UpdateSlider(int delta)
    {
        slider.value = (float)_playerHealthReference.CurrentHealth / _playerHealthReference.MaxHealth;
    }
}
