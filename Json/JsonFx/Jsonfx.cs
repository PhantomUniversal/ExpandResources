using System.Collections.Generic;
using UnityEngine;
using JsonFx.Json;
using System.Collections;

public class Json
{
    public static string Write(Dictionary<string, object> dic)
    {
        return JsonWriter.Serialize(dic);
    }

    public static Dictionary<string, object> Read(string json)
    {
        return JsonReader.Deserialize<Dictionary<string, object>>(json);
    }
}

public class Jsonfx : MonoBehaviour
{
    void Start()
    {
        Dictionary<string, object> dicJson = new Dictionary<string, object>();
        dicJson.Add("name", "chang_ho");
        dicJson.Add("age", 27);

        ArrayList arr = new ArrayList();
        arr.Add("c");
        arr.Add("c++");
        arr.Add("c#");
        arr.Add("php");
        arr.Add("java script");
        dicJson.Add("program language", arr);

        string strJson = Json.Write(dicJson);
        Debug.Log("name : " + dicJson["name"]);
        Debug.Log("age : " + dicJson["age"]);

        dicJson = Json.Read(strJson);
        Debug.Log("name : " + dicJson["name"]);
        Debug.Log("age : " + dicJson["age"]);

        string[] strs = (string[])dicJson["program language"];
        for(int i = 0; i < strs.Length; i++)
        {
            Debug.Log("program language : " + strs[i]);
        }

    }
}
