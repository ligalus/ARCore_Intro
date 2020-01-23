using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class FoodController : MonoBehaviour
{

    private DetectedPlane detectedPlane;
    private GameObject foodInstance; //edamas senes
    private GameObject foodInstance2; //needamas senes
    private GameObject foodInstance3; //augi

    private float foodAge;
    private readonly float maxAge = 10f;

    public GameObject[] foodModels; //edamas senes
    public GameObject[] notFoodModels; //needamas senes
    public GameObject[] plants; //augi


    public void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        detectedPlane = selectedPlane;
    }


    void SpawnFoodInstance() //edamas senes
    {
        GameObject foodItem = foodModels[Random.Range(0, foodModels.Length)];

        // Pick a location.  This is done by selecting a vertex at random and then
        // a random point between it and the center of the plane.
        List<Vector3> vertices = new List<Vector3>();
        detectedPlane.GetBoundaryPolygon(vertices);
        Vector3 pt = vertices[Random.Range(0, vertices.Count)];
        float dist = Random.Range(0.05f, 1f);
        Vector3 position = Vector3.Lerp(pt, detectedPlane.CenterPose.position, dist);
        // Move the object above the plane.
        position.y += .05f;


        Anchor anchor = detectedPlane.CreateAnchor(new Pose(position, Quaternion.identity));

        foodInstance = Instantiate(foodItem, position, Quaternion.identity,
                 anchor.transform);

        // Set the tag.
        foodInstance.tag = "food";

        foodInstance.transform.localScale = new Vector3(.025f, .025f, .025f);
        foodInstance.transform.SetParent(anchor.transform);
        foodAge = 0;

        /////////Liek senem rotet pa savu Y asi
        //foodInstance.AddComponent<FoodMotion>(); 
    }

    void SpawnFoodInstance2() //needamas senes
    {
        GameObject foodItem = notFoodModels[Random.Range(0, notFoodModels.Length)];

        // Pick a location.  This is done by selecting a vertex at random and then
        // a random point between it and the center of the plane.
        List<Vector3> vertices = new List<Vector3>();
        detectedPlane.GetBoundaryPolygon(vertices);
        Vector3 pt = vertices[Random.Range(0, vertices.Count)];
        float dist = Random.Range(0.05f, 1f);
        Vector3 position = Vector3.Lerp(pt, detectedPlane.CenterPose.position, dist);
        // Move the object above the plane.
        position.y += .05f;


        Anchor anchor = detectedPlane.CreateAnchor(new Pose(position, Quaternion.identity));

        foodInstance2 = Instantiate(foodItem, position, Quaternion.identity,
                 anchor.transform);

        // Set the tag.
        foodInstance2.tag = "notfood";

        foodInstance2.transform.localScale = new Vector3(.025f, .025f, .025f);
        foodInstance2.transform.SetParent(anchor.transform);
        foodAge = 0;

        /////////Liek senem rotet pa savu Y asi
        //foodInstance.AddComponent<FoodMotion>(); 
    }

    void SpawnFoodInstance3() //needamas senes
    {
        GameObject foodItem = plants[Random.Range(0, plants.Length)];

        // Pick a location.  This is done by selecting a vertex at random and then
        // a random point between it and the center of the plane.
        List<Vector3> vertices = new List<Vector3>();
        detectedPlane.GetBoundaryPolygon(vertices);
        Vector3 pt = vertices[Random.Range(0, vertices.Count)];
        float dist = Random.Range(0.05f, 1f);
        Vector3 position = Vector3.Lerp(pt, detectedPlane.CenterPose.position, dist);
        // Move the object above the plane.
        position.y += .05f;


        Anchor anchor = detectedPlane.CreateAnchor(new Pose(position, Quaternion.identity));

        foodInstance3 = Instantiate(foodItem, position, Quaternion.identity,
                 anchor.transform);

        // Set the tag.
        foodInstance3.tag = "notfood";

        foodInstance3.transform.localScale = new Vector3(.025f, .025f, .025f);
        foodInstance3.transform.SetParent(anchor.transform);
        foodAge = 0;

        /////////Liek senem rotet pa savu Y asi
        //foodInstance.AddComponent<FoodMotion>(); 
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPlane == null)
        {
            return;
        }

        if (detectedPlane.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        // Check for the plane being subsumed
        // If the plane has been subsumed switch attachment to the subsuming plane.
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

        //edamas senes
        if (foodInstance == null || foodInstance.activeSelf == false)
        {
            SpawnFoodInstance();
            return;
        }

        foodAge += Time.deltaTime;
        if (foodAge >= maxAge)
        {
            DestroyObject(foodInstance);
            foodInstance = null;
        }


        //needamas senes
        if (foodInstance2 == null || foodInstance2.activeSelf == false)
        {
            SpawnFoodInstance2();
            return;
        }

        foodAge += Time.deltaTime;
        if (foodAge >= maxAge)
        {
            DestroyObject(foodInstance2);
            foodInstance2 = null;
        }


        //augi
        if (foodInstance3 == null || foodInstance3.activeSelf == false)
        {
            SpawnFoodInstance3();
            return;
        }

        foodAge += Time.deltaTime;
        if (foodAge >= maxAge)
        {
            DestroyObject(foodInstance3);
            foodInstance3 = null;
        }


    }
}
