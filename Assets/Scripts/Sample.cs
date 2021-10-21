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


    // �C���[�W(Resources) �� byte�z��
    public byte[] ImageToBytes(string name)
    {
        TextAsset text_asset = Resources.Load<TextAsset>(name);
        return text_asset.bytes;
    }

    // �C���[�W(Resources) �� Base64
    string ImageToBase64(string path)
    {
        byte[] byteArray = ImageToBytes(path);
        return Convert.ToBase64String(byteArray);
    }

    // byte�z�� �� �C���[�W(Texture)
    Texture BytesToTexture(byte[] byteArray, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(byteArray);
        return texture;
    }

    // Base64 �� �C���[�W(Texture)
    Texture Base64ToImage(string base64Text, int width, int height)
    {
        byte[] byteArray = Convert.FromBase64String(base64Text);
        return BytesToTexture(byteArray, width, height);
    }

    // �X�^�[�g���ɌĂ΂��
    void Start()
    {
        // �C���[�W�̕\��
        string base64Text = ImageToBase64("cat");
        Texture texture = Base64ToImage(base64Text, 400, 400);
        image.texture = texture;

        // �摜���ނ̎��s
        //Predict("data:image/jpeg;base64," + base64Text);
        label.text = VersionNumber().ToString();
        Hello();
    }

    //�e�L�X�g�̎w��
    public void SetText(string text)
    {
        //�e�L�X�g�̎w��
        label.text = text;
    }
}