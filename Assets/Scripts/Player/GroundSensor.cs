using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public int GroundContact;

    public bool IsGrounded()
    {
        return (GroundContact > 0);
    }

    void OnTriggerEnter2D()
    {
        GroundContact++;
    }

    void OnTriggerExit2D()
    {
        GroundContact--;
    }
}
