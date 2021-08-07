using System.Collections;
using System.Collections.Generic;
using LO.VTT;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TestTools;

public class SimpleScriptTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SimpleScriptTestWithEnumeratorPasses()
    {
        var go = new GameObject();
        go.transform.position = Vector3.zero;
        var simpleScript = go.AddComponent<SimpleScript>();
        simpleScript.movement = new Mover {velocity = 1};
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(5);
        float3 currentPosition = go.transform.position;
        var epsilon = new float3(0.1f, 0.1f, 0.1f);
        var difference = math.abs((new float3(0, 5, 0)) - currentPosition);
        Assert.IsTrue(math.all(difference < epsilon));
        yield return new WaitForSeconds(6);
        currentPosition = go.transform.position;
        difference = math.abs((new float3(0, 9, 0)) - currentPosition);
        Assert.IsTrue(math.all(difference < epsilon));
        yield return new WaitForSeconds(7);
        currentPosition = go.transform.position;
        difference = math.abs((new float3(0, 2, 0)) - currentPosition);
        Assert.IsTrue(math.all(difference < epsilon));
        yield return new WaitForSeconds(4);
        currentPosition = go.transform.position;
        difference = math.abs((new float3(0, 2, 0)) - currentPosition);
        Assert.IsTrue(math.all(difference < epsilon));
    }
}
