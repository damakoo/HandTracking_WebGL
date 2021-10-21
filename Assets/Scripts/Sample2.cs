using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using System.IO;
public class Sample2 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern float Result();
  
    public Text label;
    private void Update()
    {
        string txt = null;
        /*var result = Result();
        foreach (var key in result)
        {
            txt += key.ToString();
        }*/
        //Result();
        label.text = Result().ToString();
    }
}
