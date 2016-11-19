using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawFPS : MonoBehaviour {

    float deltaTime = 0.0f;
    Text fpsText;

    void Start()
    {
        fpsText = this.gameObject.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        //GUIStyle style = new GUIStyle();

        //Rect rect = new Rect(0, 0, w, h * 2 / 100);
        //style.alignment = TextAnchor.UpperLeft;
        //style.fontSize = h * 2 / 100;
        //style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);


        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        fpsText.text = "FPS: " + text;
        //GUI.Label(rect, text, style);
    }
}
