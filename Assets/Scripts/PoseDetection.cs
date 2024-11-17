using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoseDetection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUi;
    public OVRHand rightOVRHand;
    public OVRHand leftOVRHand;
    private bool hasFingerPinched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRHand.TrackingConfidence confidence = rightOVRHand.GetFingerConfidence(OVRHand.HandFinger.Index);
        bool fingerPinched = rightOVRHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (!hasFingerPinched && fingerPinched && confidence == OVRHand.TrackingConfidence.High)
        {
            hasFingerPinched = true;
            PoseDetected(" ");
        }
        else if (hasFingerPinched && !fingerPinched)
        {
            hasFingerPinched = false;
        }
    }

    public void PoseDetected(string character)
    {
        string newText = textUi.text + character;
        if (newText.Length > 8)
        {
            newText = newText.Substring(newText.Length - 8);
        }
        textUi.text = newText;
    }
}
