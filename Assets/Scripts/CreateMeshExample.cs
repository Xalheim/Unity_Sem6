using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor.ProBuilder;
using UnityEngine;
using UnityEngine.ProBuilder;

public class CreateMeshExample : MonoBehaviour
{

    public Material platformMaterial;
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        BasicPlatform();   
    }

    public void BasicPlatform()
    {
        ProBuilderMesh platform = ProBuilderMesh.Create
        (
            new Vector3[]
            {
                spawnPosition + new Vector3(0f, 0f, 0f),
                spawnPosition + new Vector3(3f, 0f, 0f),
                spawnPosition + new Vector3(0f, 0f, 3f),
                spawnPosition + new Vector3(3f, 0f, 3f),
                spawnPosition + new Vector3(0f, -1f, 0f),
                spawnPosition + new Vector3(3f, -1f, 0f),
                spawnPosition + new Vector3(0f, -1f, 3f),
                spawnPosition + new Vector3(3f, -1f, 3f)
            },
            new Face[]
            {
                new Face(new int[] {0, 2, 1}),
                new Face(new int[] {2, 3, 1}),
                new Face(new int[] {5, 6, 4}),
                new Face(new int[] {5, 7, 6}),
                new Face(new int[] {0, 6, 2}),
                new Face(new int[] {4, 6, 0}),
                new Face(new int[] {5, 4, 0}),
                new Face(new int[] {5, 0, 1}),
                new Face(new int[] {7, 3, 2}),
                new Face(new int[] {6, 7, 2}),
                new Face(new int[] {7, 1, 3}),
                new Face(new int[] {7, 5, 1})
            }
        );

        platform.gameObject.AddComponent<MeshCollider>();
        platform.SetMaterial(platform.faces, platformMaterial);
        platform.Refresh();
        platform.ToMesh();
    }

}
