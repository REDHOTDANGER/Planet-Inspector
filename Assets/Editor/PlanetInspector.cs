using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class PlanetInspector : Editor
{

    PlanetBase planetBase;

    private void OnEnable()
    {
        planetBase = (PlanetBase)target;
    }

    public override void OnInspectorGUI()
    {
        PlanetDetails();
        PlanetEnvironment();
        PlanetLife();
        //base.OnInspectorGUI();
    }

    public void PlanetDetails()
    {

        EditorGUILayout.LabelField("Planet Details", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        //main color
        planetBase.mainColor = EditorGUILayout.ColorField(new GUIContent("Planet color", "The primary color of the planet. The earth is mostly blue, fyi."), planetBase.mainColor);
        
        //size
        planetBase.planetSize = EditorGUILayout.IntSlider(new GUIContent("Planet Radius", "Radius of the planet in miles (circumference of earth is 24,901 miles)."), planetBase.planetSize, 100, 1000000);

        //amount of moons
        planetBase.moonAmount = EditorGUILayout.IntSlider(new GUIContent("Amount of Moons", "Number of moons orbiting the planet. Earth has one. Duh."), planetBase.moonAmount, 1, 100);
        
        //revolution time
        planetBase.revolutionTime = EditorGUILayout.FloatField(new GUIContent("Revolution Time", "Time in Earth hours it takes to complete a single revolution."), planetBase.revolutionTime);

        if (planetBase.revolutionTime < 0)
            planetBase.revolutionTime = 0;

        //orbit time
        planetBase.orbitTime = EditorGUILayout.FloatField(new GUIContent("Orbit Time", "Time in Earth hours it takes to orbit once."), planetBase.orbitTime);

        if (planetBase.orbitTime < 0)
            planetBase.orbitTime = 0;

        //main elements
        
        serializedObject.Update();
        //GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
        //myStyle.alignment = TextAnchor.MiddleCenter;
        SerializedProperty myElem = serializedObject.FindProperty("mainElements");
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(10);
        EditorGUILayout.PropertyField(myElem, new GUIContent("Elements", "List of elements present in planet, i.e. earth's core is nickel and iron, oxygen and nitrogen are present in the atmosphere, etc"), true);
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();


        EditorGUILayout.EndVertical();
    }

    public void PlanetEnvironment()
    {
        EditorGUILayout.LabelField("Planet Environment", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField(new GUIContent("Temperature Range", "Lowest and highest temperature of planet in Celcius (average earth temp is 14.6°C"));
        //lowest temp & highest temp
        EditorGUILayout.MinMaxSlider(ref planetBase.lowTemp, ref planetBase.highTemp, -100, 200);
        //EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Low Temp: " + planetBase.lowTemp.ToString("F2") + "°C");
        EditorGUILayout.LabelField("High Temp: " + planetBase.highTemp.ToString("F2") + "°C");
        //EditorGUILayout.EndHorizontal();

        //radiation amount
        planetBase.radiationAmount = EditorGUILayout.FloatField(new GUIContent("Radiation Amount", "Ambient radiation amount in mSv (Earth has an average of 1.26 mSv/a)"), planetBase.radiationAmount);

        if (planetBase.radiationAmount < 0)
            planetBase.radiationAmount = 0;

        //lowest elevation
        planetBase.lowElevation = EditorGUILayout.FloatField(new GUIContent("Lowest Elevation", "In miles. Negative values are below sea level if planet has water"), planetBase.lowElevation);

        //highest elevation
        planetBase.highElevation = EditorGUILayout.FloatField(new GUIContent("Highest Elevation", "In miles. I.E. Earth's highest elevation is 29,035 miles (mt everest)"), planetBase.highElevation);

        if (planetBase.highElevation < 0)
            planetBase.highElevation = 0;
        EditorGUILayout.EndVertical();
    }

    public void PlanetLife()
    {
        EditorGUILayout.LabelField("Planet Life", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");

        //is habitable? (toggle group)
        planetBase.isHabitable = EditorGUILayout.BeginToggleGroup(new GUIContent("Planet habitable", "Planet can support life for extended duration?"), planetBase.isHabitable);


        //has flora? (only if habitable)
        planetBase.flora = EditorGUILayout.Toggle(new GUIContent("Planet Has Flora", "E.g. plant life"), planetBase.flora);

        //has fauna? (only if has flora)
        planetBase.fauna = EditorGUILayout.Toggle(new GUIContent("Planet Has fauna", "E.g. animal life"), planetBase.fauna);

        if(planetBase.isHabitable == false)
        {
            planetBase.flora = false;
            planetBase.fauna = false;
        }

        EditorGUILayout.EndToggleGroup();

        //has water? (toggle)
        planetBase.hasWater = EditorGUILayout.Toggle("Has Water?", planetBase.hasWater);

        //any intelligent creatures and how many?
        planetBase.intelligentCreatures = EditorGUILayout.BeginToggleGroup(new GUIContent("Planet Has Intelligent Creatures", "Is the planet full of strange wildlife or functioning alien societies?"), planetBase.intelligentCreatures);
        planetBase.icPopulation = EditorGUILayout.IntField(new GUIContent("Intelligent Creatures", "Populous of intelligent life on the planet."), planetBase.icPopulation);
        if (planetBase.icPopulation < 0)
            planetBase.icPopulation = 0;

        if(planetBase.intelligentCreatures == false)
        {
            planetBase.icPopulation = 0;
        }
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndVertical();
    }

}
