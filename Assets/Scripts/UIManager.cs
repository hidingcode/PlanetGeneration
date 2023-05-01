using System;
using System.Collections;
using System.Collections.Generic;
using HidingcodeGenericLib.UI.QuickUIManagers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] private SphereDensity sphereDensity;
    [SerializeField] private MeshGenerator meshGenerator;
    [SerializeField] private TextUIManager textUIManager;
    
    [Header("Sliders")]
    [SerializeField] private Slider radiusSlider;
    [SerializeField] private Slider noiseScaleSlider;
    [SerializeField] private Slider noiseHeightMultiplierSlider;
    [SerializeField] private Slider boundSizeSlider;
    [SerializeField] private Slider numPointsPerAxisSlider;

    private void Start()
    {
        InitSliders();
    }

    public void InitSliders()
    {
        radiusSlider.value = sphereDensity.radius;
        noiseScaleSlider.value = sphereDensity.noiseScale;
        noiseHeightMultiplierSlider.value = sphereDensity.noiseHeightMultiplier;
        boundSizeSlider.value = meshGenerator.boundsSize;
        numPointsPerAxisSlider.value = meshGenerator.numPointsPerAxis;
    }

    public void UpdateRadius() {
        float radius = radiusSlider.value;
        sphereDensity.SetRadius(radius);
        textUIManager.SetText("Planet Radius", ((int)radius).ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateNoiseScale() {
        float noiseScale = noiseScaleSlider.value;
        sphereDensity.SetNoiseScale(noiseScale);
        textUIManager.SetText("Noise Scale", ((int)noiseScale).ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateNoiseHeightMultiplier() {
        float noiseHeightMultiplier = noiseHeightMultiplierSlider.value;
        sphereDensity.SetNoiseHeightMultiplier(noiseHeightMultiplier);
        textUIManager.SetText("Noise Height Multiplier", ((int)noiseHeightMultiplier).ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateBoundSize() {
        
        float boundSize = boundSizeSlider.value;
        meshGenerator.SetBoundSize(boundSize);
        textUIManager.SetText("Bound Size", ((int)boundSize).ToString());
    }
    
    public void UpdateNumPointsPerAxis() {
        int numPointsPerAxis = (int)numPointsPerAxisSlider.value;
        meshGenerator.SetNumPointsPerAxis(numPointsPerAxis);
        textUIManager.SetText("Num Points Per Axis", numPointsPerAxis.ToString());
    }
}
