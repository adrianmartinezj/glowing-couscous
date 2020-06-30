using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entry : MonoBehaviour
{
    void Start()
    {
        // UI layer
        gameObject.layer = 5;
        RectTransform rect = gameObject.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2 { x = 0, y = 1 };
        rect.anchorMax = new Vector2 { x = 1, y = 1 };
        rect.pivot = new Vector2 { x = 0, y = 1 };
        rect.sizeDelta = new Vector2 { x = 0, y = 30 };

        CanvasRenderer renderer = gameObject.AddComponent<CanvasRenderer>();
        Text text = gameObject.AddComponent<Text>();
        text.text = "Test";

    }
}
