using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;

public class HandLog : MonoBehaviour
{
    public OVRSkeleton rightOVRSkeleton;
    public OVRHand leftOVRHand;
    private bool hasFingerPinched = false;
    private static readonly HttpClient client = new HttpClient();
    [SerializeField] private TextMeshProUGUI textUi;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRHand.TrackingConfidence confidence = leftOVRHand.GetFingerConfidence(OVRHand.HandFinger.Index);
        bool fingerPinched = leftOVRHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (!hasFingerPinched && fingerPinched && confidence == OVRHand.TrackingConfidence.High)
        {
            hasFingerPinched = true;
            SendHandJointsInfo();
        }
        else if (hasFingerPinched && !fingerPinched)
        {
            hasFingerPinched = false;
        }
            
    }

    void SendData(List<Vector3> data)
    {
        string jsonData = ConvertToJson(data);
        Debug.Log(jsonData);

        StartCoroutine(SendPostRequest("http://10.88.126.140:5001/data", jsonData));
    }

    private string ConvertToJson(List<Vector3> data)
    {
        string json = "[";
        for(int i = 0; i < data.Count; i++)
        {
            json += "{\"x\": " + data[i].x + ", \"y\": " + data[i].y + ", \"z\": " + data[i].z + "}";
            if (i != data.Count - 1)
            {
                json += ", ";
            }
        }
        json += "]";
        return json;
    }

    void SendHandJointsInfo()
    {
        List<Vector3> info = GetHandJointsInfo();
        if (info == null)
        {
            Debug.Log("No Joint!");
            return;
        }
        SendData(info);
    }

    List<Vector3> GetHandJointsInfo()
    {
        IList<OVRBone> bones = rightOVRSkeleton.Bones;
        if (bones.Count == 0)
        {
            return null;
        }

        List<Vector3> handJoints = new();
        for (int i = (int)OVRPlugin.BoneId.Hand_Start; i < (int)OVRPlugin.BoneId.Hand_End; i++)
        {
            handJoints.Add(bones[i].Transform.position);
        }

        return handJoints;
    }

    IEnumerator SendPostRequest(string url, string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData, "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.downloadHandler.text);
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                UpdateText(www.downloadHandler.text);
            }
        }
    }

    void UpdateText(string newValue)
    {
        string newText = textUi.text + newValue;
        if(newText.Length > 8)
        {
            newText = newText.Substring(newText.Length - 8);
        }
        textUi.text = newText;
    }
}
