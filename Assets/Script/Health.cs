using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public bool IsShielded { get; private set; }

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction<int> OnHeal;

    public event UnityAction OnDeath
    {
        add => _onDeath.AddListener(value);
        remove => _onDeath.RemoveListener(value);
    }

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negative");
        
        if (!IsShielded)
        {
            var tmp = CurrentHealth;
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            var delta = CurrentHealth - tmp;
            OnDamage?.Invoke(delta);

            if (CurrentHealth <= 0)
            {
                _onDeath?.Invoke();
            }
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negative");

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        var delta = CurrentHealth - tmp;
        OnHeal?.Invoke(amount);
    }

    public void SetShield(bool val)
    {
        IsShielded = val;
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while (enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {
        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;


        //
        yield break;
    }
}