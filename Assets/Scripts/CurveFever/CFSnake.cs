using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CFSnake : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    float horizontal = 0f;

    public XboxController controller;

    public PlayerScore ps;
    public BattleManager bm;
    private bool isDead = false;
        

    // Update is called once per frame
    void Update()
    {
        horizontal = XCI.GetAxisRaw(XboxAxis.LeftStickX, controller);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            if (isDead)
            {
                return;
            }
            speed = 0f;
            rotationSpeed = 0f;

            //GameObject.FindObjectOfType<CFGameManager>().EndGame();
            isDead = true;
            ps.score -= bm.playersLeft - 1;
            //ps.UpdateScore();
            bm.playersLeft--;
        }
    }
}
