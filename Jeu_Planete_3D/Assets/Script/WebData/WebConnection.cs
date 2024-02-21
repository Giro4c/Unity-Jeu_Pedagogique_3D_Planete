using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class WebConnection
{

    [SerializeField] private string host;

    public WebConnection(string host)
    {
        this.host = host;
    }

    public string GetHost()
    {
        return host;
    }

    public void SetHost(string val)
    {
        this.host = val;
    }

}
