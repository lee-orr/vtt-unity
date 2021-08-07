using System.Collections;
using System.Collections.Generic;
using LO.VTT;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TestTools;

public class SimpleTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void MoverUpdatesMovementCorrectly()
    {
        var m = new Mover();
        m.velocity = 10;
        float3 newPosition = m.UpdateMove(1, float3.zero, new float3(0, 1, 0));
        
        Assert.AreEqual(new float3(0,10,0), newPosition);
    }
}
