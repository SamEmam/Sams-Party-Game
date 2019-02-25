using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BSScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;
    public BSGameManager BSGM;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        BSGM.OnCubeSpawned += BSGameManager_OnCubeSpawned;
    }

    private void OnDestroy()
    {
        BSGM.OnCubeSpawned -= BSGameManager_OnCubeSpawned;
    }

    private void BSGameManager_OnCubeSpawned()
    {
        score++;
        text.text = "Score: " + score;
    }
}
