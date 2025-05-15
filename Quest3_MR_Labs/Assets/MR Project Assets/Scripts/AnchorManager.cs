using System.Collections.Generic;
using UnityEngine;

public class AnchorTutorialUIManager : MonoBehaviour
{
    public GameObject saveablePrefab;
    public GameObject nonSaveablePrefab;
    public Transform saveablePlacement;
    public Transform nonSaveablePlacement;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            CreateGreenCapsule();
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            CreateRedCapsule();
        }
        else if (OVRInput.GetDown(OVRInput.Button.One)) // A
        {
            LoadAnchors();
        }
        else if (OVRInput.GetDown(OVRInput.Button.Three)) // Y
        {
            EraseAnchors();
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two)) // B or X
        {
            DestroyAllCapsules();
        }
    }

    void CreateGreenCapsule()
    {
        GameObject capsule = Instantiate(saveablePrefab, saveablePlacement.position, Quaternion.identity);
        var anchor = capsule.AddComponent<OVRSpatialAnchor>();
        anchor.Save();
        spawnedObjects.Add(capsule);
    }

    void CreateRedCapsule()
    {
        GameObject capsule = Instantiate(nonSaveablePrefab, nonSaveablePlacement.position, Quaternion.identity);
        spawnedObjects.Add(capsule);
    }

    void LoadAnchors()
    {
        // Not implemented in sample. You can load from IDs here.
        Debug.Log("Loading anchors...");
    }

    void EraseAnchors()
    {
        Debug.Log("Erasing not yet implemented.");
    }

    void DestroyAllCapsules()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }

        spawnedObjects.Clear();
    }
}
