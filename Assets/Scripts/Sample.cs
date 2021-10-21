using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using System.IO;

public class Sample : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern float VersionNumber();
    [DllImport("__Internal")]
    private static extern void Hello();
    //private static extern void Predict(string base64Text);

    // UI
    public RawImage image;
    public Text label;


    // イメージ(Resources) → byte配列
    public byte[] ImageToBytes(string name)
    {
        TextAsset text_asset = Resources.Load<TextAsset>(name);
        return text_asset.bytes;
    }

    // イメージ(Resources) → Base64
    string ImageToBase64(string path)
    {
        byte[] byteArray = ImageToBytes(path);
        return Convert.ToBase64String(byteArray);
    }

    // byte配列 → イメージ(Texture)
    Texture BytesToTexture(byte[] byteArray, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(byteArray);
        return texture;
    }

    // Base64 → イメージ(Texture)
    Texture Base64ToImage(string base64Text, int width, int height)
    {
        byte[] byteArray = Convert.FromBase64String(base64Text);
        return BytesToTexture(byteArray, width, height);
    }

    // スタート時に呼ばれる
    void Start()
    {
        // イメージの表示
        string base64Text = ImageToBase64("cat");
        Texture texture = Base64ToImage(base64Text, 400, 400);
        image.texture = texture;

        // 画像分類の実行
        //Predict("data:image/jpeg;base64," + base64Text);
        label.text = VersionNumber().ToString();
        Hello();
    }

    //テキストの指定
    public void SetText(string text)
    {
        //テキストの指定
        label.text = text;
    }
}