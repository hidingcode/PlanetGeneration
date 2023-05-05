using UnityEngine;

namespace Density
{
    public class SphereDensity : DensityGenerator {
    
        [Header ("Sphere Noise")]
        public float radius = 1;
        public int numOctaves = 6;
        public float lacunarity = 2;
        public float persistence = .5f;
        public float noiseScale = 1;
        public float noiseHeightMultiplier = 1;

        public override ComputeBuffer Generate (ComputeBuffer pointsBuffer, int numPointsPerAxis, float boundsSize, Vector3 worldBounds, Vector3 centre, Vector3 offset, float spacing) {
            densityShader.SetFloat ("radius", radius);
            densityShader.SetInt ("octaves", Mathf.Max (1, numOctaves));
            densityShader.SetFloat ("lacunarity", lacunarity);
            densityShader.SetFloat ("persistence", persistence);
            densityShader.SetFloat ("noiseScale", noiseScale);
            densityShader.SetFloat("noiseHeightMultiplier", noiseHeightMultiplier);
            return base.Generate (pointsBuffer, numPointsPerAxis, boundsSize, worldBounds, centre, offset, spacing);
        }
    
        public void SetRadius(float radius) {
            this.radius = radius;
        }
    
        public void SetNoiseScale(float noiseScale) {
            this.noiseScale = noiseScale;
        }
    
        public void SetNoiseHeightMultiplier(float noiseHeightMultiplier) {
            this.noiseHeightMultiplier = noiseHeightMultiplier;
        }
    }
}