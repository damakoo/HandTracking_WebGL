using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class ReceiveResult : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Result();
    [DllImport("__Internal")]
    private static extern string GetLocalStorage(string key);
    [DllImport("__Internal")]
    private static extern void SetLocalStorage(string key, string value);
    public Vector3[] landmarks { get; set; } = new Vector3[21];
    //public Vector3[] landmarks = new Vector3[21];
    public Text label;
    public void SetText(string text)
    {
        label.text = text;
    }

    void Update()
    {
        Result();
        var jsonstr = GetLocalStorage("handpos");
        SetText(jsonstr);
        //Debug.Log(jsonstr);
        landmarks = JsonHelper.FromJson<Vector3>(jsonstr);
        //landmarks.print();
    }
}
