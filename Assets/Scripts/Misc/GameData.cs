using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static string GetGameProperty(string id, JSONObject info)
    {
        if (info.keys != null && info.keys.Contains(id))
        {
            return info[id].str;
        }

        return "";
    }

    public static string GetGameProperty(string id, List<JSONObject> infoList)
    {
        if (infoList == null)
            return "";

        foreach (JSONObject info in infoList)
        {
            return GetGameProperty(id, info);
        }

        return "";
    }

    public static bool HasGameProperty(string id, JSONObject info)
    {
        for (int i = 0; i < info.list.Count; i++)
        {
            if (info.keys[i] == id)
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasGameProperty(string id, List<JSONObject> infoList)
    {
        foreach (JSONObject info in infoList)
        {
            if (HasGameProperty(id, info))
                return true;
        }

        return false;
    }


    public static string GetProperty(string getprop, string properties)
    {
        string[] tmpData = properties.Split(',');
        int _prop_count = tmpData.Length;

        for (int i = 0; i < _prop_count; i++)
        {
            if (getprop == tmpData[i])
            {
                return tmpData[i + 1];
            }
        }

        return "";
    }

    public static int GetParam(string getprop, string properties)
    {
        string[] tmpData = properties.Split(',');
        int _prop_count = tmpData.Length;

        for (int i = 0; i < _prop_count; i++)
        {
            if (getprop == tmpData[i])
            {
                return int.Parse(tmpData[i + 1]);
            }
        }

        return 0;
    }

    public static float GetParamFloat(string getprop, string properties)
    {
        string[] tmpData = properties.Split(',');
        int _prop_count = tmpData.Length;

        for (int i = 0; i < _prop_count; i++)
        {
            if (getprop == tmpData[i])
            {
                return float.Parse(tmpData[i + 1]);
            }
        }

        return 0;
    }

    public static bool HasParam(string getprop, string properties)
    {
        string[] tmpData = properties.Split(',');
        int _prop_count = tmpData.Length;

        for (int i = 0; i < _prop_count; i++)
        {
            if (getprop == tmpData[i])
            {
                return true;
            }
        }

        return false;
    }


    public static List<JSONObject> CreateGameInfoList(JSONObject info)
    {
        List<JSONObject> gameInfoList = new List<JSONObject>();

        string infoBaseType = "";
        gameInfoList.Add(info);
        infoBaseType = GetGameProperty("Base", info);

        do
        {
            if (infoBaseType != "")
            {
                //TE TODO JSONObject infoBase = GameManager.Instance.GetGameInfo(infoBaseType);
                //gameInfoList.Add(infoBase);
                //infoBaseType = GetGameProperty("Base", infoBase);
            }

        } while (infoBaseType != "");

        return gameInfoList;
    }
}
