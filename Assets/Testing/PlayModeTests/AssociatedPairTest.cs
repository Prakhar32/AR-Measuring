using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class AssociatedPairTest
{
    [UnityTest]
    public IEnumerator convertorMissing()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        AssociatedPair pair = g.AddComponent<AssociatedPair>();
        yield return null;
        Assert.IsTrue(pair == null);
    }

    [UnityTest]
    public IEnumerator initialisedSuccessfully()
    {
        AssociatedPair pair = composedObject();
        yield return null;
        Assert.IsTrue(pair != null);
    }

    private AssociatedPair composedObject()
    {
        Convertor convertor = new Convertor();
        GameObject g = new GameObject("Pair");
        AssociatedPair pair = g.AddComponent<AssociatedPair>();
        pair.SetConvertor(convertor);
        return pair;
    }

    [UnityTest]
    public IEnumerator pairSet()
    {
        AssociatedPair pair = composedObject();
        yield return null;
        GameObject g1 = new GameObject();
        GameObject g2 = new GameObject();
        g2.transform.position = Vector3.one;
        pair.FirstOfPairSet(g1);
        pair.SecondOfPairSet(g2, Vector3.up);
        yield return null;
        Assert.IsTrue(pair != null);
    }
}
