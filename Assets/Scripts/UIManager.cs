using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Slider frequencySlider;
    [SerializeField] private Slider amplitudeSlider;
    [SerializeField] private Slider noiseSlider;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        winPanel.SetActive(false);
    }
    public void SetSliderLimits(float minFrequency, float maxFrequency, float minAmplitude, float maxAmplitude, float minNoise, float maxNoise)
    {
        frequencySlider.minValue = minFrequency;
        frequencySlider.maxValue = maxFrequency;
        amplitudeSlider.minValue = minAmplitude;
        amplitudeSlider.maxValue = maxAmplitude;
        noiseSlider.minValue = minNoise;
        noiseSlider.maxValue = maxNoise;
        noiseSlider.value = (minNoise + maxNoise) / 2f;
        amplitudeSlider.value = (minAmplitude + maxAmplitude) / 2f;
        frequencySlider.value = (minFrequency + maxFrequency) / 2f;
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

}
