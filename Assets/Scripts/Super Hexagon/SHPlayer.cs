using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class SHPlayer : MonoBehaviour
{
    public float moveSpeed = 600f;

    public XboxController controller;

    float movement = 0f;

    public BattleManager bm;

    // Update is called once per frame
    void Update()
    {
        movement = XCI.GetAxisRaw(XboxAxis.LeftStickX, controller);
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }

        PlayerScore ps = GetComponent<PlayerScore>();
        ps.score -= bm.playersLeft - 1;
        ps.UpdateScore();
        bm.playersLeft--;
        Destroy(this.gameObject);
    }
}
