using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Pointsss : MonoBehaviour
{
    public bool isSelected;
    public GameObject test;
    public GameObject ParentObj;
    public int ID;
    List<GameObject> ClearPoints = new List<GameObject>();
    
    void Start()
    {
        ParentObj = transform.parent.gameObject;
       
    }
    public GameObject selectedObject;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("to world " + Input.mousePosition + "position: " + transform.position);
    }
    private void OnMouseDown()
    {
        isSelected = true;
        test = new GameObject();
        if(test.transform.childCount == 0)
        {
            test.tag = "Destroy";

        }
        ClearPoints.Add(test);
        switch (ID)
        {
            case 0:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[0].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 0.ToString();
                // test.transform.parent = GetComponentInParent<BoundingBoxScript>().Points[7].transform;

                break;
            case 1:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[1].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 1.ToString();
                break;
            case 2:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[2].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 2.ToString();
                break;
            case 3:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[3].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 3.ToString();
                break;
            case 4:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[4].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 4.ToString();
                break;
            case 5:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[5].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 5.ToString();
                break;
            case 6:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[6].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 6.ToString();
                break;
            case 7:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[7].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 7.ToString();
                break;
            case 8:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[8].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 8.ToString();
                break;
            case 9:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[9].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 9.ToString();
                break;
            case 10:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[10].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 10.ToString();
                break;
            case 11:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[11].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 11.ToString();
                break;           
            case 12:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[12].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 12.ToString();
                break;          
            case 13:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[13].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 13.ToString();
                break;         
            case 14:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[14].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 14.ToString();
                break;           
            case 15:
                test.transform.position = GetComponentInParent<BoundingBoxScript>().pivots[15].transform.position;
                ParentObj.transform.parent = test.transform;
                test.name = 15.ToString();
                break;

        }




    }


    private void OnMouseUp()
    {
      //  test.transform.parent = null;
        isSelected =false;
      
        
    }
   
}
