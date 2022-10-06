using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] GoodFoods;
    public GameObject[] BadFoods;

    private int goodFoodCount = 10;
    private int badFoodCount = 5;

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

    // Update is called once per framew
    void Update()
    {
    }

    private void PopulateFoodLocationsArray()
    {
        // Defining food locations
        foodLocations.Add(new Vector3(-2.856f, 1.526f, 5.722f));
        foodLocations.Add(new Vector3(-1.301f, 0.201f, 5.722f));
        foodLocations.Add(new Vector3(4.4741f, 1.264f, 3.816f));
        foodLocations.Add(new Vector3(5.397f, 0.2f, -4.872214f)); // closet near bedroom
        foodLocations.Add(new Vector3(-6.067554f, 1.527f, -0.2253566f)); //computer table
        foodLocations.Add(new Vector3(3.839324f, 0.265f, 7.453134f));// closet near kitchen
        foodLocations.Add(new Vector3(2.918487f, 1.549f, -10.5524f)); //bathroom sink
        foodLocations.Add(new Vector3(-4.732743f, 1.149f, -8.872142f)); //master bedroom bed
        foodLocations.Add(new Vector3(-7.26672f, 1.138f, 6.847778f)); //small bedroom bed
        foodLocations.Add(new Vector3(5.45f, 1.09109f, -0.08671708f)); //bench
        foodLocations.Add(new Vector3(-0.197128f, 0.341f, -9.097137f)); //master bedroom closet
        foodLocations.Add(new Vector3(-6.721f, 1.3278f, -4.52f)); //master bedroom cupboard
        foodLocations.Add(new Vector3(-2.9821f, 0.91f, 6.733f)); //kitchen oven
        foodLocations.Add(new Vector3(3.130547f, 0.852f, -10.616f)); //bathroom drawer
        foodLocations.Add(new Vector3(-7.42775f, 0.274f, -7.982955f)); //master bedroom floor

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
