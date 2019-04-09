using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerScore ps;
    public FinishLine fl;
    public TextMeshProUGUI distanceDial;
    private int speed;

    private void Update()
    {
        var velocity = rb.velocity.magnitude * 3;
        speed = (int)velocity;
        distanceDial.text = speed + " km/h \n " + (ps.laps + 1) + "/" + fl.raceLaps + " LAPS";
    }
}
