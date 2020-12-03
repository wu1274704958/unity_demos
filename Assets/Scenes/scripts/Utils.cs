using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{

    public static IEnumerator DelayToInvokeDo(System.Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

    public static void Delay(MonoBehaviour obj,System.Action action, float delaySeconds)
    {
        obj.StartCoroutine(Utils.DelayToInvokeDo(action, delaySeconds));
    }

}
