using UnityEngine;
using System.Collections;

public class CubeStates : MonoBehaviour {
    public bool currentlyShowCubes = true;
    public int cubeGroupID = 0;
    public GameObject[] cubeGroups;

    void ChangeShadows(bool showCubes)
    {
        foreach (MeshRenderer renderer in cubeGroups[cubeGroupID].GetComponentsInChildren<MeshRenderer>())
        {
            renderer.shadowCastingMode = showCubes ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }

        currentlyShowCubes = showCubes;
    }

    void ChangeGroupID(int newID)
    {
        cubeGroups[cubeGroupID].SetActive(false);
        cubeGroupID = newID;
        cubeGroups[cubeGroupID].SetActive(true);
    }
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChangeGroupID(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGroupID(1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeShadows(!currentlyShowCubes);
        }
	}
}
