using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] GoodFoods;
    public GameObject[] BadFoods;

    private int goodFoodCount = 2;
    private int badFoodCount = 0;

    private List<Vector3> foodLocations = new List<Vector3>();
    private bool[] occupiedLocations;

    // Start is called before the first frame update
    void Start()
    {
        // Store locations in an array
        PopulateFoodLocationsArray();

        // Find empty food locations to spawn them
        var goodFoodLocations = GetEmptyFoodLocations(goodFoodCount);
        var badFoodLocations = GetEmptyFoodLocations(badFoodCount);

        // Spawn foods at the empty locations
        SpawnFoodAtLocations(GoodFoods, goodFoodLocations);
        SpawnFoodAtLocations(BadFoods, badFoodLocations);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PopulateFoodLocationsArray()
    {
        // Defining food locations
        foodLocations.Add(new Vector3(-2.856f, 1.526f, 5.722f));
        foodLocations.Add(new Vector3(-1.301f, 0.201f, 5.722f));

        // Create a list of occupied locations equal to number of food locations
        occupiedLocations = new bool[foodLocations.Count];
    }

    private Vector3[] GetEmptyFoodLocations(int count)
    {
        // Define list to store empty food locations
        List<Vector3> locations = new List<Vector3>();

        // Loop until we find the desired empty food locations
        for( int i=0; i<count; i++)
        {
            // Get a random food location
            int randomIndex = Random.Range(0, foodLocations.Count);
            // Check if the food location is empty
            if (!occupiedLocations[randomIndex])
            {
                locations.Add(foodLocations[randomIndex]);
                occupiedLocations[randomIndex] = true;
            } 
            else
            {
                // Retry if the current location is not empty
                i--;
            }
        }

        return locations.ToArray();
    }
    private void SpawnFoodAtLocations(GameObject[] foods, Vector3[] locations)
    {
        // Spawning food at defined locations
        for(int i= 0; i< locations.Length; i++)
        {
            int randomFoodIndex = Random.Range(0, foods.Length);
            Instantiate(foods[randomFoodIndex], locations[i], Quaternion.identity);
        }
    }
}
