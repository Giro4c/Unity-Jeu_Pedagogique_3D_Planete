using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EllipseTest
{
    
    /* --------------------------------------- *
     *               EVALUATE                  *
     * --------------------------------------- */
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
    
    
    /* ---------------------------------------------------- *
     *                  FIND PROGRESS USING X               *
     * ---------------------------------------------------- */
    
    
    [Test]
    public void EllipseFindProgressUsingXProgress0()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 10;
        float y = 1;
        float progress = 0f;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));
        
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
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

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
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

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
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressOneNegativeXAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-10, 5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressOneNegativeYAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingXProgressNegativeAxises()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingX(x, y)));

    }
    
    
    /* ---------------------------------------------------- *
     *                  FIND PROGRESS USING Y               *
     * ---------------------------------------------------- */

    [Test]
    public void EllipseFindProgressUsingYProgress0()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 1f;
        float y = 0f;
        float progress = 0f;
        
        // Tests
        Debug.Log(ellipse.FindProgressUsingY(x, y));
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressHalf()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = -1f;
        float y = 0f;
        float progress = 0.5f;
        
        // Tests
        Debug.Log(ellipse.FindProgressUsingY(x, y));
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressQuarter()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 1f;
        float y = 5f;
        float progress = 0.25f;
        
        // Tests
        Debug.Log(ellipse.FindProgressUsingY(x, y));
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressMinusQuarter()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, 5);
        
        // Declare
        float x = 1f;
        float y = -5f;
        float progress = 0.75f;
        
        // Tests
        Debug.Log(ellipse.FindProgressUsingY(x, y));
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressOneNegativeXAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-10, 5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressOneNegativeYAxis()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
    [Test]
    public void EllipseFindProgressUsingYProgressNegativeAxises()
    {
        // Constructor
        Ellipse ellipse = new Ellipse(-10, -5);
        float progress = 0.42f;
        Vector2 coordinates = ellipse.Evaluate(progress);
        
        // Declare
        float x = coordinates.x;
        float y = coordinates.y;
        
        // Tests
        Assert.True(Mathf.Approximately(progress,ellipse.FindProgressUsingY(x, y)));

    }
    
}
