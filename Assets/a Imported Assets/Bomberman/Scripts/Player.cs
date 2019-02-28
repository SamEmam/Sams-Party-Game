/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using System;
using XboxCtrlrInput;

public class Player : MonoBehaviour
{
    public BattleManager bm;
    public ParticleSystem deathEffect;

    //Player parameters
    [Range (1, 4)] //Enables a nifty slider in the editor
    public int playerNumber = 1;
    //Indicates what player this is: P1 or P2
    public float moveSpeed = 5f;
    public bool canDropBombs = true;
    //Can the player drop bombs?
    public bool canMove = true;
    //Can the player move?

    public bool dead = false;
    //Is the player dead?

    public int startBombs = 2;
    private int currentBombs;
    private float bombReload = 2f;
    //Amount of bombs the player has left to drop, gets decreased as the player
    //drops a bomb, increases as an owned bomb explodes

    //Prefabs
    public GameObject bombPrefab;

    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;


    public XboxController controller;
    public bool isPreGame = false;


    // Use this for initialization
    void Start ()
    {
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody> ();
        myTransform = transform;
        animator = myTransform.Find ("PlayerModel").GetComponent<Animator> ();
        currentBombs = startBombs;
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateMovement ();
        if (currentBombs < startBombs && bombReload <= 0f)
        {
            currentBombs++;
            bombReload = 2f;
        }
        else if (currentBombs == startBombs)
        {
            bombReload = 2f;
        }
        else
        {
            bombReload -= Time.deltaTime;
        }
        
    }

    private void UpdateMovement ()
    {
        animator.SetBool ("Walking", false);

        if (!canMove)
        { //Return if player can't move
            return;
        }

        //Depending on the player number, use different input for moving
        UpdatePlayerMovement();
    }

    /// <summary>
    /// Updates Player 1's movement and facing rotation using the WASD keys and drops bombs using Space
    /// </summary>
    private void UpdatePlayerMovement ()
    {
        if (XCI.GetAxis(XboxAxis.LeftStickY, controller) > 0)
        { //Up movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 0, 0);
            animator.SetBool ("Walking", true);
        }

        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0)
        { //Left movement
            rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 270, 0);
            animator.SetBool ("Walking", true);
        }

        if (XCI.GetAxis(XboxAxis.LeftStickY, controller) < 0)
        { //Down movement
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 180, 0);
            animator.SetBool ("Walking", true);
        }

        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0)
        { //Right movement
            rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 90, 0);
            animator.SetBool ("Walking", true);
        }

        if (canDropBombs && XCI.GetButtonDown(XboxButton.A, controller))
        { //Drop bomb
            DropBomb ();
        }
    }
    

    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    private void DropBomb ()
    {
        if (bombPrefab && currentBombs > 0)
        { //Check if bomb prefab is assigned first
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x),
                        bombPrefab.transform.position.y,
                        Mathf.RoundToInt(myTransform.position.z)),
                        bombPrefab.transform.rotation);

            currentBombs--;
            
        }
    }

    public void OnTriggerEnter (Collider other)
    {
        if (isPreGame)
        {
            return;
        }
        if (other.CompareTag ("Explosion"))
        {
            
            if (dead)
            {
                return;
            }
            PlayerScore ps = GetComponent<PlayerScore>();
            ps.score -= bm.playersLeft - 1;
            ps.UpdateScore();
            bm.playersLeft--;
            Destroy(this.gameObject);
            Instantiate(ps.finishParticles, transform.position, Quaternion.LookRotation(Vector3.up));
            dead = true; // 1
        }
    }
}
