using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractible
{
    event UnityAction OnPickUp;

    bool TryPickUp();
}