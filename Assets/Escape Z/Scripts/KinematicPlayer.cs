using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicPlayer : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        Kinematic();
    }

    void Kinematic()
    {
        PlayerRigidbody.isKinematic = true;
    }
}
