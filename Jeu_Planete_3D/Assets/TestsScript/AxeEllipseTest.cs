using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AxeEllipseTests
{
    [UnityTest]
    public IEnumerator LineRenderer_Exists()
    {
        GameObject gameObject = new GameObject();
        AxeEllipse axeEllipse = gameObject.AddComponent<AxeEllipse>();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        yield return null;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        Assert.NotNull(lineRenderer);
    }

    [UnityTest]
    public IEnumerator LineRenderer_PositionCount_Correct()
    {
        GameObject gameObject = new GameObject();
        AxeEllipse axeEllipse = gameObject.AddComponent<AxeEllipse>();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        axeEllipse.semiMajorAxis = 2f;
        axeEllipse.semiMinorAxis = 1f;

        yield return null;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        Assert.AreEqual(axeEllipse.segments + 1, lineRenderer.positionCount);
    }

    [UnityTest]
    public IEnumerator LineRenderer_Positions_CorrectX()
    {
        GameObject gameObject = new GameObject();
        AxeEllipse axeEllipse = gameObject.AddComponent<AxeEllipse>();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        axeEllipse.semiMajorAxis = 2f;
        axeEllipse.semiMinorAxis = 1f;

        yield return null;

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        for (int i = 0; i <= axeEllipse.segments; i++)
        {
            float angle = 360f * Mathf.Deg2Rad * i / axeEllipse.segments;
            float x = 1;
            float y = 0;
            Vector3 expectedPoint = new Vector3(x, 0f, y);

            Assert.AreEqual(expectedPoint.x, lineRenderer.GetPosition(i).x, 0.001f);
      
        }
    }
    [UnityTest]
    public IEnumerator LineRenderer_Positions_CorrectY()
    {
        GameObject gameObject = new GameObject();
        AxeEllipse axeEllipse = gameObject.AddComponent<AxeEllipse>();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        axeEllipse.semiMajorAxis = 2f;
        axeEllipse.semiMinorAxis = 1f;

        yield return null;

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        for (int i = 0; i <= axeEllipse.segments; i++)
        {
            float angle = 360f * Mathf.Deg2Rad * i / axeEllipse.segments;
            float x = 1;
            float y = 0;
            Vector3 expectedPoint = new Vector3(x, 0f, y);

            
            Assert.AreEqual(expectedPoint.y, lineRenderer.GetPosition(i).y, 0.001f);
            
        }
    }
    [UnityTest]
    public IEnumerator LineRenderer_Positions_CorrectZ()
    {
        GameObject gameObject = new GameObject();
        AxeEllipse axeEllipse = gameObject.AddComponent<AxeEllipse>();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        axeEllipse.semiMajorAxis = 2f;
        axeEllipse.semiMinorAxis = 1f;

        yield return null;

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        for (int i = 0; i <= axeEllipse.segments; i++)
        {
            float angle = 360f * Mathf.Deg2Rad * i / axeEllipse.segments;
            float x = 1;
            float y = 0;
            Vector3 expectedPoint = new Vector3(x, 0f, y);

            
            Assert.AreEqual(expectedPoint.z, lineRenderer.GetPosition(i).z, 0.001f);
        }
    }
}
