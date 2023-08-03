using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoundingBoxScript : MonoBehaviour
{

    public CustomGizmoSelection customGizmoSelection;
    public GameObject objectToSpawn; // The object you want to spawn at the pivot points
    public int numberOfObjectsToSpawn = 9; // Number of objects to spawn at each pivot point
        public List< GameObject> pivots = new List<GameObject>();

    private BoxCollider boxCollider;
    private int selectedPivotIndex = -1;


    void Start()
    {
        customGizmoSelection = GameObject.FindObjectOfType<CustomGizmoSelection>();
        objectToSpawn = Resources.Load("Sphere") as GameObject;
        boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            
            Debug.LogError("BoxCollider component not found on the GameObject.");
            return;
        }

        // Calculate the pivot points around the box collider
        Vector3[] pivotPoints = CalculatePivotPoints();

        // Spawn objects at the pivot points
        SpawnObjectsAtPivotPoints(pivotPoints);
    }

    Vector3[] CalculatePivotPoints()
    {
        Vector3[] pivotPoints = new Vector3[16];

        Vector3 center = boxCollider.center;
        Vector3 size = boxCollider.size * 0.5f;

        pivotPoints[0] = center + new Vector3(size.x, size.y, size.z);
        pivotPoints[1] = center + new Vector3(size.x, size.y, -size.z);
        pivotPoints[2] = center + new Vector3(-size.x, size.y, size.z);
        pivotPoints[3] = center + new Vector3(-size.x, size.y, -size.z);

        pivotPoints[4] = center + new Vector3(size.x, -size.y, size.z);
        pivotPoints[5] = center + new Vector3(size.x, -size.y, -size.z);
        pivotPoints[6] = center + new Vector3(-size.x, -size.y, size.z);
        pivotPoints[7] = center + new Vector3(-size.x, -size.y, -size.z);

        pivotPoints[8] = center + new Vector3(size.x, size.y, 0);
        pivotPoints[9] = center + new Vector3(0, size.y, size.z);
        pivotPoints[10] = center + new Vector3(-size.x, size.y, 0);
        pivotPoints[11] = center + new Vector3(0, size.y, -size.z);
        
        pivotPoints[12] = center + new Vector3(size.x, -size.y, 0);
        pivotPoints[13] = center + new Vector3(0, -size.y, size.z);
        pivotPoints[14] = center + new Vector3(-size.x, -size.y, 0);
        pivotPoints[15] = center + new Vector3(0, -size.y, -size.z);


        return pivotPoints;
    }

    void SpawnObjectsAtPivotPoints(Vector3[] pivotPoints)
    {
        BoxCollider test = gameObject.GetComponent<BoxCollider>();
        for (int i = 0; i < pivotPoints.Length; i++)
        {
            GameObject go = Instantiate(objectToSpawn, pivotPoints[i], Quaternion.identity);
            go.transform.parent = transform;
            pivots.Add(go);
            go.GetComponent<Pointsss>().ID = i;
            go.transform.localScale = new Vector3(test.size.x/6, test.size.x / 6, test.size.x / 6);



        }
    }
    
    

    private void Update()
    {
        TogglePivot();
        //  Objcollider.size = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any of the pivot points
            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < pivots.Count; i++)
                {
                    if (hit.collider.gameObject == pivots[i])
                    {
                        // If a pivot point is selected, save its index
                        selectedPivotIndex = i;
                        break;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Reset the selected pivot index when the mouse button is released
            selectedPivotIndex = -1;
        }
    }

    public void TogglePivot()
    {
        foreach (var item in pivots)
        {
           item.SetActive(customGizmoSelection.toggle.isOn);
        }
    }

}
