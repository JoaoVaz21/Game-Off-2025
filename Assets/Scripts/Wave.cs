using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wave : MonoBehaviour
{
    public int pointsCount = 100; // Number of points in the line
    public float lineLength = 10f; // Length of the line on the x-axis
    public float amplitude = 1f; // Amplitude of the wave
    public float frequency = 1f; // Frequency of the wave
    public float phaseShift = 0f; // Phase shift of the wave
    public float speed = 1f; // Speed of the wave animation
    public float noiseScale = 1f; // Scale of the noise
    public float noiseIntensity = 0.5f; // Intensity of the noise

    private LineRenderer lineRenderer;
    private float time;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount;
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        UpdateWave();
    }

    void UpdateWave()
    {
        Vector3[] positions = new Vector3[pointsCount];
        float step = lineLength / (pointsCount - 1);

        for (int i = 0; i < pointsCount; i++)
        {
            float x = this.transform.position.x + i * step;
            float y = this.transform.position.y + Mathf.Sin((x * frequency) + time + phaseShift) * amplitude;

            // Add Perlin noise to the wave
            float noise = Mathf.PerlinNoise(x * noiseScale, 0) * noiseIntensity;
            y += noise;

            positions[i] = new Vector3(x, y, 0);
        }

        lineRenderer.SetPositions(positions);
    }
}