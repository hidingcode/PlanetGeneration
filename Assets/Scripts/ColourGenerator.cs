﻿using UnityEngine;

[ExecuteInEditMode]
public class ColourGenerator : MonoBehaviour {
    public Material mat;
    public Gradient gradient;
    public float normalOffsetWeight;

    Texture2D texture;
    const int textureResolution = 50;

    void Init () {
        if (texture == null || texture.width != textureResolution) {
            texture = new Texture2D (textureResolution, 1, TextureFormat.RGBA32, false);
        }
    }

    void Update () {
        Init ();
        UpdateTexture ();
        MeshGenerator m = FindObjectOfType<MeshGenerator> ();

        float boundsY = m.boundsSize * m.numChunks.y / 2f;


        mat.SetFloat ("boundsY", boundsY);
        mat.SetFloat ("normalOffsetWeight", normalOffsetWeight);

        mat.SetTexture ("ramp", texture);
    }

    void UpdateTexture () {
        if (gradient != null) {
            Color[] colours = new Color[texture.width];
            for (int i = 0; i < textureResolution; i++) {
                float distFromCenter = Mathf.Abs(i - (texture.width - 1) / 2f) / ((texture.width - 1) / 2f);
                Color gradientCol = gradient.Evaluate(distFromCenter);
                colours[i] = gradientCol;
            }
            texture.SetPixels (colours);
            texture.Apply ();
        }
    }
}