using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class BlackScreen : MonoBehaviour
{
    public bool Showed;
    private RectTransform rectTransform;
    private Image image;

    // Start is called before the    first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Showed && image.color.a < 1)
        {
            image.color = new Color(0, 0, 0, Mathf.Lerp(image.color.a, 1, 0.05f));
        }

        if (!Showed && image.color.a > 0)
        {
            image.color = new Color(0, 0, 0, Mathf.Lerp(image.color.a, 0, 0.05f));
        }
    }
}
