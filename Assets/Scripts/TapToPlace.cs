using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;

    public GameObject objectPrefab;

    GameObject spawnedPrefab;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Vector2 touchPosition;

    private void Awake()
    {
        raycastManager = this.GetComponent<ARRaycastManager>();
    }
    
    public bool TryToGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryToGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        PlaceObject();
    }

    public void PlaceObject()
    {
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedPrefab == null)
            {
                spawnedPrefab = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedPrefab.transform.position = hitPose.position;
            }
        }
    }
}
