using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public int seconds = 300;
    private TextMeshPro timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Timer Text").GetComponent<TextMeshPro>();
        timeText.color = Color.green;
        StartCoroutine(Countdown(seconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayTime(int seconds)
    {
        int minutes = seconds / 60;
        int secs = seconds % 60;
        timeText.SetText(string.Format("{0}:{1}", minutes.ToString("D2"), secs.ToString("D2")));
        if (seconds == 60)
        {
            timeText.color = Color.red;
        }
    }
    
    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter >= 0)
        {
            yield return new WaitForSeconds(1);
            DisplayTime(counter);
            counter--;
        }
    }
}
