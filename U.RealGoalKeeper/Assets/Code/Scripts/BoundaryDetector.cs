using System.Runtime.CompilerServices;
using UnityEngine;

public class BoundaryDetector
{
    public enum TypeBoundary 
    {
        None,
        Stationary,
        RoomScale,
        Dev
    }

    public static TypeBoundary CheckBoundaryType()
    {
        OVRBoundary bounds = new OVRBoundary();

        if (bounds.GetConfigured())
        {
            Vector3 dimensions = bounds.GetDimensions(OVRBoundary.BoundaryType.PlayArea);
            Debug.Log($"Boundary Dimensions: {dimensions.x} x {dimensions.z}");

            // A common "hack" is to check if the area is small and perfectly square
            if (Mathf.Approximately(dimensions.x, dimensions.z) && dimensions.x < 2.1f)
            {
                Debug.Log("Likely in STATIONARY mode.");
                return TypeBoundary.Stationary;
            }
            else
            {
                Debug.Log("Likely in ROOM SCALE mode.");
                return TypeBoundary.RoomScale;
            }
        }
        else
        {
            Debug.Log("No Boundary configured (Boundaryless/Dev Mode).");
            return TypeBoundary.Dev;
        }
    }
}