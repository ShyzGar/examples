using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;

    float second;

    void Start()
    {
        second = float.Parse(text.text);
    }

    void FixedUpdate()
    {
        if (second >= 1)
        {
            second -= 0.02f;
            text.text = ((int)second).ToString();
        }

        else
            text.text = "!!!";
    }
}