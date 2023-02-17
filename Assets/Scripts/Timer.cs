using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime; 
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimeFormats format;
    private Dictionary<TimeFormats, string> timeFormats = new Dictionary<TimeFormats, string>();


    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimeFormats.Whole, "0");
        timeFormats.Add(TimeFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimeFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit || (!countDown && currentTime >= timerLimit))))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();

        

        
    }

    private void SetTimerText()
        {
            timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
        }


}

public enum TimeFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}