using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTBStartText : MonoBehaviour
{
    public Text text;
    public string[] message;
    public float messageTime = 1f;
    public float destroyTime = 3f;
    private int i = 0;
    private float countdown;
    private bool hasStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        text.text = message[i];
        countdown = messageTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStopped)
        {
            return;
        }
        countdown -= Time.deltaTime;
        if (countdown <= 0 && i < message.Length)
        {
            i++;
            text.text = message[i];
            countdown = messageTime;
        }

        if (i == message.Length)
        {
            text.text = "";
            hasStopped = true;
        }
    }
}
