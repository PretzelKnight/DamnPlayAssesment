using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public abstract class GetAPIInfo<T> : MonoBehaviour where T : new()
{
    [SerializeField] string URL;

    public void GetData()
    {
        StartCoroutine(FetchData());
    }

    public void GetImage(RawImage img, string url)
    {
        StartCoroutine(DownloadImage(img, url));
    }

    private IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                T info = new();
                //WriteString(request.downloadHandler.text);
                info = JsonUtility.FromJson<T>(request.downloadHandler.text);
                OnFetch(info);
            }
        }
    }

    private IEnumerator DownloadImage(RawImage img, string url)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                img.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
        }
    }

    static void WriteString(string str)
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(str);
        writer.Close();
    }

    protected abstract void OnFetch(T info);
}