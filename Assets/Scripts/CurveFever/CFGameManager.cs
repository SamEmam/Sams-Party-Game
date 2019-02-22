using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CFGameManager : MonoBehaviour
{
    private bool hasEnded = false;

    public void EndGame()
    {
        if (hasEnded)
        {
            return;
        }
        hasEnded = true;
        StartCoroutine(PlayEndGameAnimation());
    }

    IEnumerator PlayEndGameAnimation()
    {
        Debug.Log("Game Over");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
