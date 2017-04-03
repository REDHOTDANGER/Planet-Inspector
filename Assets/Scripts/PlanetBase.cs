using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBase : MonoBehaviour
{
    public Color mainColor; //used to color the planet
    public bool hasWater; //does it have water?
    public float highTemp, lowTemp; //range of temp
    public float revolutionTime; //How many hours a day cycle takes
    public bool fauna; //Does it have fauna, only works if the planet has flora;
    public int moonAmount; //does it have moons? How many;
    public float orbitTime; //How many planet days does it take to oribit (planet year)
    public bool isHabitable; //does it support natural life?
    public float lowElevation;// Lowest elevation
    public bool flora; //does the planet have plant life, only works if it isHa;
    public int planetSize; //radius of planet, measured in miles
    public float radiationAmount; // measured in rads
    public bool intelligentCreatures; //does it have intelligent creatures, native or otherwise;
    public float highElevation;//Highest elevation;
    public int icPopulation; //if it has intel creatures, how many;
    public string[] mainElements; // What elements it hosts;


    private GameObject[] theMoons;//used to 
                                  // Use this for initialization
    void Start()
    {
        float smallerSize = planetSize / 100;
        transform.localScale = new Vector3(smallerSize, smallerSize, smallerSize);
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        Material myMaterial = new Material(renderer.material);
        mainColor.a = 1f;
        myMaterial.color = mainColor;
        renderer.material = myMaterial;
    }

    // Update is called once per frame
    void Update()
    {

    }
}