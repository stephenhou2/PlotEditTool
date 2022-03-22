using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [ContextMenu("≤‚ ‘")]
    public void TestFunc()
    {
        var node = this.transform.Find("_TOP/_TOP_BAR/BTN_CREATE_PLOT");
        Log.Logic(node.ToString() + "11111111");
    }

    [ContextMenu("≤‚ ‘2")]
    public void TestFunc2()
    {
        var node= UIInterface.FindChildNode(this.transform, "_TOP/_TOP_BAR/BTN_CREATE_PLOT");
        Log.Logic(node.ToString() + "2222222");
    }
}
