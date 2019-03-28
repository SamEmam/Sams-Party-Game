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
        speed = (int)rb.velocity.magnitude;
        distanceDial.text = speed + " km/h \n " + (ps.laps + 1) + "/" + fl.raceLaps + " LAPS";
    }
}
