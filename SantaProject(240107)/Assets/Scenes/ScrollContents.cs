using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollContents : MonoBehaviour
{
    public ScrollRect scrollRect;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect.onValueChanged.AddListener(OnscrollEnt);
    }
    void OnscrollEnt(Vector2 position)
    {
        text.text = $"scrollbar position:{position}";
    }
}
