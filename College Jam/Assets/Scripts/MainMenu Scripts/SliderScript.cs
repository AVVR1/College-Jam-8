using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText;

    public void UpdateSliderTextValue(float value)
    {
        sliderText.text = value.ToString();
    }
}
