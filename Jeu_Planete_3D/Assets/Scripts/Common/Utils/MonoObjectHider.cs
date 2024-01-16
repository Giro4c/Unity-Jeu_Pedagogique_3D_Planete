using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoObjectHider : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    public void Hide()
    {
        obj.SetActive(false);
    }
    
    public void Show()
    {
        obj.SetActive(true);
    }
    
    public void InvertActive()
    {
        obj.SetActive(!obj.activeSelf);
    }
    
}
