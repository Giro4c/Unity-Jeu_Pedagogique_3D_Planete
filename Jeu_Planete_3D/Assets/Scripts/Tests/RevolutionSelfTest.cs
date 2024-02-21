using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
/*
public class RevolutionSelfTest
{
    
    [Test]
    public void RevolutionSelfTestEvaluateInitial()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(new Vector3(42, 56, 180), Vector3.up);
        float progress = 0f;
        Quaternion resultExpect = Quaternion.Euler(42, 56, 180);
        Assert.AreEqual(resultExpect, revolutionSelf.Evaluate(progress));

    }
    
    [Test]
    public void RevolutionSelfTestEvaluateEigthFract()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0.125f;
        Quaternion resultExpect = Quaternion.Euler(0, 45, 0);
        Assert.AreEqual(resultExpect, revolutionSelf.Evaluate(progress));

    }
    
    [Test]
    public void RevolutionSelfTestEvaluateQuarter()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0.25f;
        Quaternion resultExpect = Quaternion.Euler(0, 90, 0);
        Assert.AreEqual(resultExpect, revolutionSelf.Evaluate(progress));

    }
    
    [Test]
    public void RevolutionSelfTestFindProgressInit()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0f;
        Quaternion quaterProgress = revolutionSelf.Evaluate(progress);
        Assert.True(Mathf.Approximately(progress, revolutionSelf.FindProgress(quaterProgress)));
    }
    
    [Test]
    public void RevolutionSelfTestFindProgressQuarter()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0.25f;
        Quaternion quaterProgress = revolutionSelf.Evaluate(progress);
        Assert.True(Mathf.Approximately(progress, revolutionSelf.FindProgress(quaterProgress)));
    }
    
    [Test]
    public void RevolutionSelfTestFindProgressMinusQuarter()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0.75f;
        Quaternion quaterProgress = revolutionSelf.Evaluate(progress);
        //Debug.Log("Expected " + progress + " Result " + revolutionSelf.FindProgress(quaterProgress));
        Assert.True(Mathf.Approximately(progress, revolutionSelf.FindProgress(quaterProgress)));
    }
    
    [Test]
    public void RevolutionSelfTestFindProgressCloseToOne()
    {
        RevolutionSelf revolutionSelf = new RevolutionSelf(Vector3.zero, Vector3.up);
        float progress = 0.98f;
        Quaternion quaterProgress = revolutionSelf.Evaluate(progress);
        
        Assert.True(Mathf.Approximately(progress, revolutionSelf.FindProgress(quaterProgress)));
    }

    
}*/
