
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StrengthSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public WindArea area;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { sliderText.text = v.ToString("0.00"); area.strength = v; });
    }

}

