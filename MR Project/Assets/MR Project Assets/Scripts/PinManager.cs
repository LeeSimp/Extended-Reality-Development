using UnityEngine;
using System.Linq;

public class PinManager : MonoBehaviour
{
    public BowlingPin[] pins;

    public int CountStandingPins()
    {
        return pins.Count(pin => pin.IsStanding);
    }

    public void ResetPins()
    {
        foreach (var pin in pins)
        {
            // Reset rotation & position as needed
            pin.transform.rotation = Quaternion.identity;
            // Place pin at initial position or store original position
        }
    }
}
