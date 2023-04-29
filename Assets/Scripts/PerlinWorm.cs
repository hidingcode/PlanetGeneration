using UnityEngine;
using System.Collections;

public class PerlinWorm : MonoBehaviour {
    public int numSegments = 10;
    public float segmentLength = 1.0f;
    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    public float noiseScale = 1.0f;
    public float threshold = 0.5f;

    private Mesh mesh;
    private Vector3[] vertices;
    private float[] offsets;

    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        offsets = new float[numSegments];
        for (int i = 0; i < numSegments; i++) {
            offsets[i] = Random.Range(0, 10000);
        }
        for (int i = 0; i < vertices.Length; i++) {
            float x = vertices[i].x;
            float y = Mathf.PerlinNoise(x * frequency, offsets[i % numSegments]) * amplitude;
            float z = Mathf.PerlinNoise(x * frequency, offsets[(i + 1) % numSegments]) * amplitude;
            if (y < threshold && z < threshold) {
                vertices[i] = new Vector3(x, y, z);
            } else {
                vertices[i] = Vector3.zero;
            }
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals(); 
        gameObject.AddComponent<MeshCollider>();
    }
}