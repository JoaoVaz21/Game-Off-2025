using UnityEngine;

namespace Assets.Scripts
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private float minAmplitude = 0.5f;
        [SerializeField] private float maxAmplitude = 2.0f;
        [SerializeField] private float amplitudeErrorThresholf = 0.1f;
        [SerializeField] private float minFrequency = 0.5f;
        [SerializeField] private float maxFrequency = 2.0f;
        [SerializeField] private float frequencyErrorThreshold = 0.1f;
        [SerializeField] private float minNoiseScale = 0.0f;
        [SerializeField] private float maxNoiseScale = 10.0f;
        [SerializeField] private float noiseErrorThreshold = 0.5f;


        [SerializeField] private Wave goalWave;
        [SerializeField] private Wave activeWave;
        [SerializeField] private UIManager uiManager;

        private void Awake()
        {
            uiManager.SetSliderLimits(minFrequency, maxFrequency, minAmplitude, maxAmplitude, minNoiseScale, maxNoiseScale);
            activeWave.frequency = (minFrequency + maxFrequency) / 2;
            activeWave.amplitude = (minAmplitude + maxAmplitude) / 2;
            activeWave.noiseScale = (minNoiseScale + maxNoiseScale) / 2;
            var goalFrequency = Random.Range(minFrequency, maxFrequency);
            var goalAmplitude = Random.Range(minAmplitude, maxAmplitude);
            var goalNoiseScale = Random.Range(minNoiseScale, maxNoiseScale);
            goalWave.frequency = goalFrequency;
            goalWave.amplitude = goalAmplitude;
            goalWave.noiseScale = goalNoiseScale;
        }


        public void OnFrequencyChanged(float newFrequency)
        {
            activeWave.frequency = newFrequency;
            CheckWinCondition();
        }
        public void OnAmplitudeChanged(float newAmplitude)
        {
            activeWave.amplitude = newAmplitude;
            CheckWinCondition();
        }
        public void OnNoiseScaleChanged(float newNoiseScale)
        {
            activeWave.noiseScale = newNoiseScale;
            CheckWinCondition();
        }
        private void CheckWinCondition()
        {
            var isFrequencyMatch = Mathf.Abs(activeWave.frequency - goalWave.frequency) <= frequencyErrorThreshold;
            var isAmplitudeMatch = Mathf.Abs(activeWave.amplitude - goalWave.amplitude) <= amplitudeErrorThresholf;
            var isNoiseScaleMatch = Mathf.Abs(activeWave.noiseScale - goalWave.noiseScale) <= noiseErrorThreshold;
            if (isFrequencyMatch && isAmplitudeMatch && isNoiseScaleMatch)
            {
                uiManager.ShowWinPanel();
            }
        }
    }
}