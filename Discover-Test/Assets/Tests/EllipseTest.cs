using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EllipseTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void EllipseEvaluatePositiveAxises()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(1000, 500);
        
        // Declare
        float progress = 0.42f;
        // Verification by approximation because exact values impossible to enter manually
        float x = -876f;
        float y = 241f;
        
        // Tests
        Vector2 result = ellipse.Evaluate(progress);
        Assert.AreEqual(x, Mathf.Ceil(result.x));
        Assert.AreEqual(y, Mathf.Ceil(result.y));
    }
    
    [Test]
    public void EllipseEvaluatePositiveYAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-1000, 500);
        
        // Declare
        float progress = 0.42f;
        // Verification by approximation because exact values impossible to enter manually
        float x = 877f;
        float y = 241f;
        
        // Tests
        Vector2 result = ellipse.Evaluate(progress);
        Assert.AreEqual(x, Mathf.Ceil(result.x));
        Assert.AreEqual(y, Mathf.Ceil(result.y));
    }
    
    [Test]
    public void EllipseEvaluatePositiveXAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(1000, -500);
        
        // Declare
        float progress = 0.42f;
        // Verification by approximation because exact values impossible to enter manually
        float x = -876f;
        float y = -240f;
        
        // Tests
        Vector2 result = ellipse.Evaluate(progress);
        Assert.AreEqual(x, Mathf.Ceil(result.x));
        Assert.AreEqual(y, Mathf.Ceil(result.y));
    }
    
    [Test]
    public void EllipseEvaluateNegativeAxises()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-1000, -500);
        
        // Declare
        float progress = 0.42f;
        // Verification by approximation because exact values impossible to enter manually
        float x = 877f;
        float y = -240f;
        
        // Tests
        Vector2 result = ellipse.Evaluate(progress);
        Assert.AreEqual(x, Mathf.Ceil(result.x));
        Assert.AreEqual(y, Mathf.Ceil(result.y));
    }
    
    
    
    
    
    
    [Test]
    public void EllipseFindProgressUsingXProgress0()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 10;
        float y = 1;
        
        // Tests
        float progress = 0f;
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressHalf()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = -10;
        float y = 0;
        float progress = 0.5f;
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressQuarter()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 0;
        float y = 1;
        float progress = 0.25f;
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressMinusQuarter()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 0;
        float y = -1;
        float progress = 0.75f;
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressOneNegativeXAxis()
    {
        Debug.Log("Test Negative X Axis");
        
        // Constructor
        Ellipse ellipse = new Ellipse(-10, 5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressOneNegativeYAxis()
    {
        Debug.Log("Test Negative Y Axis");
        
        // Constructor
        Ellipse ellipse = new Ellipse(10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressNegativeAxises()
    {
        Debug.Log("Test Negative X and Y Axis");
        
        // Constructor
        Ellipse ellipse = new Ellipse(-10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        Debug.Log("X = " + x);
        float y = coordinates.y;
        Debug.Log("Y = " + y);
        
        // Tests
        Assert.AreEqual(progress, ellipse.FindProgressUsingX(x, y));
        
    }

    
}
