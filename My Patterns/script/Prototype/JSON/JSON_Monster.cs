/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class JSON_Monster : MonoBehaviour
{
    public TextAsset txt;
    string filePath;
    string fileName;
    // Use this for initialization
    void Start()
    {
        filePath = Application.dataPath + "/JSON_TXT";
        fileName = filePath + "/Monster.txt";

        WriteJsonToFile(filePath, fileName);
    }
    void ReadJsonFromTXT()
    {
        //解析json
        JsonData jd = JsonMapper.ToObject(txt.text);
        Debug.Log("hp:" + jd["hp"]);
        Debug.Log("mp:" + jd["mp"]);
        JsonData weapon = jd["weapon"];
        //打印一下数组
        for (int i = 0; i < weapon.Count; i++)
        {
            Debug.Log("name=" + weapon["name"]);
            Debug.Log("color=" + weapon["color"]);
            Debug.Log("durability=" + weapon["durability"]);
        }
    }
    void WriteJsonToFile(string path, string fileName)
    {
        System.Text.StringBuilder strB = new System.Text.StringBuilder();
        JsonWriter jsWrite = new JsonWriter(strB);
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("Monster");
  
        jsWrite.WriteArrayStart();

        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("MonsterName");
        jsWrite.Write("Person");
        jsWrite.WritePropertyName("attack");
        jsWrite.Write(10);
        jsWrite.WritePropertyName("defense");
        jsWrite.Write(10);
        jsWrite.WritePropertyName("weapon");
        jsWrite.Write("Sword");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("MonsterName");
        jsWrite.Write("Animal");
        jsWrite.WritePropertyName("attack");
        jsWrite.Write(8);
        jsWrite.WritePropertyName("defense");
        jsWrite.Write(15);
        jsWrite.WritePropertyName("weapon");
        jsWrite.Write("tooth");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("MonsterName");
        jsWrite.Write("Dragon");
        jsWrite.WritePropertyName("attack");
        jsWrite.Write(100);
        jsWrite.WritePropertyName("defense");
        jsWrite.Write(200);
        jsWrite.WritePropertyName("weapon");
        jsWrite.Write("fire breath");
        jsWrite.WriteObjectEnd();

        jsWrite.WriteArrayEnd();
        jsWrite.WriteObjectEnd();
        Debug.Log(strB);
        //创建文件目录
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            Debug.Log("This file is already exists");
        }
        else
        {
            Directory.CreateDirectory(path);
            Debug.Log("CreateFile");
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        //把json数据写到txt里
        StreamWriter sw;
        if (File.Exists(fileName))
        {
            //如果文件存在，那么就向文件继续附加（为了下次写内容不会覆盖上次的内容)
            sw = File.AppendText(fileName);
            Debug.Log("appendText");
        }
        else
        {
            //如果文件不存在则创建文件
            sw = File.CreateText(fileName);
            Debug.Log("createText");
        }
        sw.WriteLine(strB);
        sw.Close();
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif

    }
 
}
