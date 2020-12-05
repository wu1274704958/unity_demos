using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class app : MonoBehaviour
{
    public static string ABDir = "Assets/StreamingAssets";
    private static Hashtable table = new Hashtable();
    
    public static T loadFormAB<T>(string ab_name,string name) where T: Object
    {
        AssetBundle ab = null;
        if(table.ContainsKey(ab_name))
        {
            ab = table[ab_name] as AssetBundle;
        }
        else
        {
#if UNITY_EDITOR
            ab = AssetBundle.LoadFromFile(ABDir + "/" + ab_name);
#elif UNITY_ANDROID
            ab = AssetBundle.LoadFromFile(Application.dataPath + "!assets/" + ab_name);
#else
            ab = AssetBundle.LoadFromFile(ABDir + "/" + ab_name);
#endif
            table.Add(ab_name, ab);
        }
        
        if(ab != null)
        {
            return ab.LoadAsset<T>(name);
        }
        return null;
    }
}
