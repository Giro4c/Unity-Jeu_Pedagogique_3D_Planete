using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CycleSync : MonoBehaviour
{
    [SerializeField] protected Cycle cycle;

    private void Start()
    {
        if (!CanBeEnabled())
        {
            Debug.Log("CycleSync script missing references");
            enabled = false;
        }
        SyncWithCycle();
    }

    private void Update()
    {
        SyncWithCycle();
    }

    private void OnEnable()
    {
        enabled = CanBeEnabled();
    }

    protected virtual bool CanBeEnabled()
    {
        return !(cycle == null);
    }

    protected abstract void SyncWithCycle();

}
