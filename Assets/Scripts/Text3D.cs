using System;
using TMPro;
using UnityEngine;

[Serializable]
public class Text3D
{
    [SerializeField] public GameObject ColorObject;
    [SerializeField] public GameObject DepthObject;
    private TextMeshProUGUI _colorText;
    private TextMeshProUGUI _depthText;

    public void Start()
    {
        _colorText = ColorObject.GetComponent<TextMeshProUGUI>();
        _depthText = DepthObject.GetComponent<TextMeshProUGUI>();
    }

    public bool Enabled {
        set{
            _colorText.enabled = value;
            _depthText.enabled = value;
        }
    }

    public string Text
    {
        set
        {
            _colorText.text = value;
            _depthText.text = value;
        }
    }

    public float Scale
    {
        set
        {
            var scale = new Vector3(value, value, value);
            _colorText.transform.localScale = scale;
            _depthText.transform.localScale = scale;
        }
    }

    public float Depth
    {
        set
        {
            _depthText.color = new Color(
                value,
                _depthText.color.g,
                _depthText.color.b
                );
        }
    }
}