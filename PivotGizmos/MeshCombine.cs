using Siccity.GLTFUtility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MeshCombine : MonoBehaviour
{
     GameObject CopiedMesh;
    bool isTrue = false;
    private void Update()
    {
        if (isTrue)
        {
            transform.position = CopiedMesh.transform.position;

        }

    }

    // [ContextMenu("Combine Meshes And Mat")]
    public void CombineMeshesMAT(GameObject gameObject)
    {
        // Get all MeshFilters and MeshRenderers in the current GameObject and its children
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        // Create lists to hold the meshes and materials
        Mesh[] meshes = new Mesh[meshFilters.Length];
        Material[] materials = new Material[meshRenderers.Length];

        // Collect all the meshes and materials
        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshes[i] = meshFilters[i].sharedMesh;
            materials[i] = meshRenderers[i].sharedMaterial;
        }

        // Create a new combined mesh
        Mesh combinedMesh = new Mesh();
        CombineInstance[] combineInstances = new CombineInstance[meshes.Length];

        for (int i = 0; i < meshes.Length; i++)
        {
            combineInstances[i].mesh = meshes[i];
            combineInstances[i].transform = meshRenderers[i].transform.localToWorldMatrix;
          //  meshRenderers[i].gameObject.SetActive(false); // Disable the original GameObjects to hide them
        }

        // Combine the meshes
        combinedMesh.CombineMeshes(combineInstances, true);

        // Create a new GameObject to hold the combined mesh
        GameObject combinedObject = new GameObject("CombinedMesh");
        MeshFilter combinedMeshFilter = combinedObject.AddComponent<MeshFilter>();
        MeshRenderer combinedMeshRenderer = combinedObject.AddComponent<MeshRenderer>();
        // Assign the combined mesh and materials to the new GameObject
        combinedMeshFilter.sharedMesh = combinedMesh;
        combinedMeshRenderer.sharedMaterials = materials;
        combinedObject.AddComponent<BoxCollider>();
        combinedObject.AddComponent<BoundingBoxScript>();
        combinedObject.GetComponent<BoxCollider>().enabled = false;
        // Optional: Recalculate bounds for culling and physics
        combinedMesh.RecalculateBounds();
        gameObject.transform.parent = combinedObject.transform;
        CopiedMesh = combinedObject; 
      isTrue = true;
        combinedObject.GetComponent<MeshRenderer>().enabled = false;

    }
  
}




