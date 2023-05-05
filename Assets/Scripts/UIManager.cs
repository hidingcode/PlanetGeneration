using System;
using System.Collections;
using System.Collections.Generic;
using Density;
using HidingcodeGenericLib.UI.QuickUIManagers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] private NoiseDensity terrainDensity;
    [SerializeField] private ComputeShader terrainComputeShader;
    [SerializeField] private Material terrainMaterial;
    [SerializeField] private SphereDensity sphereDensity;
    [SerializeField] private ComputeShader sphereComputeShader;
    [SerializeField] private Material sphereMaterial;
    [SerializeField] private MeshGenerator meshGenerator;
    [SerializeField] private TextUIManager textUIManager;
    
    [Header("Panels")]
    [SerializeField] private GameObject terrainPanel;
    [SerializeField] private GameObject planetPanel;
    
    [Header("Dropdown")]
    [SerializeField] private TMP_Dropdown dropdown;

    [FormerlySerializedAs("planetradiusSlider")]
    [FormerlySerializedAs("radiusSlider")]
    [Header("Sliders")]
    [Header("Terrain Sliders")]
    [SerializeField] private Slider terrainSeedSlider;
    [SerializeField] private Slider terrainOctavesSlider;
    [SerializeField] private Slider terrainLacunaritySlider;
    [SerializeField] private Slider terrainPersistenceSlider;
    [SerializeField] private Slider terrainNoiseScaleSlider;
    [SerializeField] private Slider terrainNoiseWeightSlider;
    [SerializeField] private Slider terrainNoiseWeightMultiplierSlider;

    [Space(2)]
    [Header("Planet Sliders")]
    [SerializeField] private Slider planetRadiusSlider;
    [SerializeField] private Slider planetOctavesSlider;
    [SerializeField] private Slider planetLacunaritySlider;
    [SerializeField] private Slider planetPersistenceSlider;
    [SerializeField] private Slider planetNoiseScaleSlider;
    [SerializeField] private Slider planetNoiseHeightMultiplierSlider;
    
    [Space(2)]
    [Header("Mesh Sliders")]
    [SerializeField] private Slider boundSizeSlider;
    [SerializeField] private Slider numPointsPerAxisSlider;

    private void Start()
    {
        InitSliders();
    }

    public void InitSliders()
    {   
        terrainSeedSlider.value = terrainDensity.seed;
        terrainOctavesSlider.value = terrainDensity.numOctaves;
        terrainLacunaritySlider.value = terrainDensity.lacunarity;
        terrainPersistenceSlider.value = terrainDensity.persistence;
        terrainNoiseScaleSlider.value = terrainDensity.noiseScale;
        terrainNoiseWeightSlider.value = terrainDensity.noiseWeight;
        terrainNoiseWeightMultiplierSlider.value = terrainDensity.weightMultiplier;
        
        planetRadiusSlider.value = sphereDensity.radius;
        planetLacunaritySlider.value = sphereDensity.lacunarity;
        planetPersistenceSlider.value = sphereDensity.persistence;
        planetOctavesSlider.value = sphereDensity.numOctaves;
        planetNoiseScaleSlider.value = sphereDensity.noiseScale;
        planetNoiseHeightMultiplierSlider.value = sphereDensity.noiseHeightMultiplier;
        
        boundSizeSlider.value = meshGenerator.boundsSize;
        numPointsPerAxisSlider.value = meshGenerator.numPointsPerAxis;
    }
    
    public void SwitchSettings()
    {
        if (dropdown.value == 0)
        {   
            meshGenerator.densityGenerator = terrainDensity;
            meshGenerator.mat = terrainMaterial;
            meshGenerator.SetSettingsUpdate(true);
            planetPanel.SetActive(false);
            terrainPanel.SetActive(true);
        }
        
        if (dropdown.value == 1)
        {   
            meshGenerator.densityGenerator = sphereDensity;
            meshGenerator.mat = sphereMaterial;
            meshGenerator.SetSettingsUpdate(true);
            planetPanel.SetActive(true);
            terrainPanel.SetActive(false);
        }
    }

    public void UpdateTerrainSeed()
    {
        int seed = (int)terrainSeedSlider.value;
        terrainDensity.seed = seed;
        textUIManager.SetText("Terrain Seed", seed.ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainOctaves()
    {
        int octaves = (int)terrainOctavesSlider.value;
        terrainDensity.numOctaves = octaves;
        textUIManager.SetText("Terrain Octaves", octaves.ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainLacunarity()
    {
        float lacunarity = terrainLacunaritySlider.value;
        terrainDensity.lacunarity = lacunarity;
        textUIManager.SetText("Terrain Lacunarity", lacunarity.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainPersistence()
    {
        float persistence = terrainPersistenceSlider.value;
        terrainDensity.persistence = persistence;
        textUIManager.SetText("Terrain Persistence", persistence.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainNoiseScale()
    {
        float noiseScale = terrainNoiseScaleSlider.value;
        terrainDensity.noiseScale = noiseScale;
        textUIManager.SetText("Terrain Noise Scale", noiseScale.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainNoiseWeight()
    {
        float noiseWeight = terrainNoiseWeightSlider.value;
        terrainDensity.noiseWeight = noiseWeight;
        textUIManager.SetText("Terrain Noise Weight", noiseWeight.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateTerrainNoiseWeightMultiplier()
    {
        float weightMultiplier = terrainNoiseWeightMultiplierSlider.value;
        terrainDensity.weightMultiplier = weightMultiplier;
        textUIManager.SetText("Terrain Noise Weight Multiplier", weightMultiplier.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdatePlanetRadius() {
        float radius = planetRadiusSlider.value;
        sphereDensity.SetRadius(radius);
        textUIManager.SetText("Planet Radius", radius.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }

    public void UpdatePlanetOctaves()
    {
        int octaves = (int)planetOctavesSlider.value;
        sphereDensity.numOctaves = octaves;
        textUIManager.SetText("Planet Octaves", octaves.ToString());
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdatePlanetLacunarity()
    {
        float lacunarity = planetLacunaritySlider.value;
        sphereDensity.lacunarity = lacunarity;
        textUIManager.SetText("Planet Lacunarity", lacunarity.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdatePlanetPersistence()
    {
        float persistence = planetPersistenceSlider.value;
        sphereDensity.persistence = persistence;
        textUIManager.SetText("Planet Persistence", persistence.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdatePlanetNoiseScale() {
        float noiseScale = planetNoiseScaleSlider.value;
        sphereDensity.SetNoiseScale(noiseScale);
        textUIManager.SetText("Planet Noise Scale", noiseScale.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdatePlanetNoiseHeightMultiplier() {
        float noiseHeightMultiplier = planetNoiseHeightMultiplierSlider.value;
        sphereDensity.SetNoiseHeightMultiplier(noiseHeightMultiplier);
        textUIManager.SetText("Planet Noise Height Multiplier", noiseHeightMultiplier.ToString("F1"));
        meshGenerator.SetSettingsUpdate(true);
    }
    
    public void UpdateBoundSize() {
        
        float boundSize = boundSizeSlider.value;
        meshGenerator.SetBoundSize(boundSize);
        textUIManager.SetText("Bound Size", ((int)boundSize).ToString("F1"));
    }
    
    public void UpdateNumPointsPerAxis() {
        int numPointsPerAxis = (int)numPointsPerAxisSlider.value;
        meshGenerator.SetNumPointsPerAxis(numPointsPerAxis);
        textUIManager.SetText("Num Points Per Axis", numPointsPerAxis.ToString());
    }
}
