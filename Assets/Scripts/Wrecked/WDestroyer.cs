using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WDestroyer : MonoBehaviour
{
    [Header("Preferences")]
    public Transform spawnPoint;
    public int winScore;
    private int winScoreHalf;
    public bool masterDestroyer = false;

    [Header("Setup")]
    public SceneFader sceneFader;
    public WDestroyer otherDestroyer;
    public Text message;
    public AudioListenerController audioLC;
    public WPointsBar barp1, barp2, barp3, barp4;

    [Header("Vehicle Setup")]
    public int playersLeft;
    public GameObject player1, player2, player3, player4;
    public GameObject[] p1Vehicles, p2Vehicles, p3Vehicles, p4Vehicles;
    private PlayerScore p1Score, p2Score, p3Score, p4Score;
    private WPowerUpPlayer p1Up, p2Up, p3Up, p4Up;
    private bool p1IsAlive, p2IsAlive, p3IsAlive, p4IsAlive;
    private bool hasUpdatedScore = false;
    private bool updateCooldown = true;

    private List<Vector3> spawnPositions;

    private int rewardValue;
    private int roundsPlayed;

    // Start is called before the first frame update
    void Awake()
    {
        winScoreHalf = winScore / 2;
        if (!masterDestroyer)
        {
            return;
        }

        int rng = Random.Range(0, p1Vehicles.Length);

        
        

        if (GameStats.Player1)
        {
            p1Vehicles[rng].SetActive(true);
            player1 = p1Vehicles[rng];
            otherDestroyer.player1 = player1;
            audioLC.p1 = player1.transform;
            p1Score = player1.GetComponent<PlayerScore>();
            
            p1Up = player1.GetComponent<WPowerUpPlayer>();
            p1Score.PlayerColor();
            p1IsAlive = true;
        }
        if (GameStats.Player2)
        {
            p2Vehicles[rng].SetActive(true);
            player2 = p2Vehicles[rng];
            otherDestroyer.player2 = player2;
            audioLC.p2 = player2.transform;
            p2Score = player2.GetComponent<PlayerScore>();
            
            p2Up = player2.GetComponent<WPowerUpPlayer>();
            p2Score.PlayerColor();
            p2IsAlive = true;
        }
        if (GameStats.Player3)
        {
            p3Vehicles[rng].SetActive(true);
            player3 = p3Vehicles[rng];
            otherDestroyer.player3 = player3;
            audioLC.p3 = player3.transform;
            p3Score = player3.GetComponent<PlayerScore>();
            
            p3Up = player3.GetComponent<WPowerUpPlayer>();
            p3Score.PlayerColor();
            p3IsAlive = true;
        }
        if (GameStats.Player4)
        {
            p4Vehicles[rng].SetActive(true);
            player4 = p4Vehicles[rng];
            otherDestroyer.player4 = player4;
            audioLC.p4 = player4.transform;
            p4Score = player4.GetComponent<PlayerScore>();
            
            p4Up = player4.GetComponent<WPowerUpPlayer>();
            p4Score.PlayerColor();
            p4IsAlive = true;
        }

        ResetPlayers();
        SetRewardValue();
        
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (!masterDestroyer)
        {
            return;
        }
        if (hasUpdatedScore || updateCooldown)
        {
            return;
        }

        if (playersLeft <= 1)
        {
            updateCooldown = true;
            roundsPlayed++;
            RewardLastPlayerAlive();
            if (CheckForWinner() > 0)
            {
                hasUpdatedScore = true;
                otherDestroyer.hasUpdatedScore = true;
                RewardWinner(CheckForWinner());
                StartCoroutine(EndScene());
            }
            else
            {
                playersLeft = 0;
                otherDestroyer.playersLeft = 0;
                Respawn();
                ResetPowerUps();
                ResetPlayers();
                SetRewardValue();
                StartCoroutine(Cooldown());
            }
            
            
        }
    }

    IEnumerator Cooldown()
    {
        if (playersLeft < 3)
        {
            winScore = winScoreHalf;
        }
        yield return new WaitForSeconds(2);
        
        updateCooldown = false;

    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        if (!GameStats.Player1 && !GameStats.Player2 && !GameStats.Player3 && !GameStats.Player4)
        {
            sceneFader.FadeTo("MainMenu");
        }
        sceneFader.FadeTo("ScoreScene");
    }

    public PlayerScore GetPlayerScore(int playerNum)
    {
        PlayerScore ps = p1Score;
        switch (playerNum)
        {
            case 1:
                return p1Score;
            case 2:
                return p2Score;
            case 3:
                return p3Score;
            case 4:
                return p4Score;
        }
        return ps;
    }

        

    void RewardWinner(int playerNum)
    {
        Debug.Log("RewardWinner: " + playerNum);
        switch (playerNum)
        {
            case 1:
                GameStats.Player1Score++;
                message.text += p1Score.playerColorText + " WINS!";
                Instantiate(p1Score.finishParticles, player1.transform.position, Quaternion.LookRotation(Vector3.up));
                break;
            case 2:
                GameStats.Player2Score++;
                message.text += p2Score.playerColorText + " WINS!";
                Instantiate(p2Score.finishParticles, player2.transform.position, Quaternion.LookRotation(Vector3.up));
                break;
            case 3:
                GameStats.Player3Score++;
                message.text += p3Score.playerColorText + " WINS!";
                Instantiate(p3Score.finishParticles, player3.transform.position, Quaternion.LookRotation(Vector3.up));
                break;
            case 4:
                GameStats.Player4Score++;
                message.text += p4Score.playerColorText + " WINS!";
                Instantiate(p4Score.finishParticles, player4.transform.position, Quaternion.LookRotation(Vector3.up));
                break;
        }
    }
    

    int CheckForWinner()
    {
        Debug.Log("CheckForWinner");
        if (p1Score && p1Score.score >= winScore)
        {
            return p1Score.playerNum;
        }
        else if (p2Score && p2Score.score >= winScore)
        {
            return p2Score.playerNum;
        }
        else if (p3Score && p3Score.score >= winScore)
        {
            return p3Score.playerNum;
        }
        else if (p4Score && p4Score.score >= winScore)
        {
            return p4Score.playerNum;
        }
        else
        {
            return 0;
        }
    }

    void RewardLastPlayerAlive ()
    {
        Debug.Log("RewardLastPlayerAlive");
        if (p1IsAlive)
        {
            UpdateScore(p1Score);
            //barp1.ps.score = p1Score.score;
        }
        else if (p2IsAlive)
        {
            UpdateScore(p2Score);
            //barp2.ps.score = p2Score.score;
        }
        else if (p3IsAlive)
        {
            UpdateScore(p3Score);
            //barp3.ps.score = p3Score.score;
        }
        else if (p4IsAlive)
        {
            UpdateScore(p4Score);
            //barp4.ps.score = p4Score.score;
        }
    }

    void ResetPlayers()
    {
        Debug.Log("Reset Players");
        if (GameStats.Player1)
        {
            player1.SetActive(true);
            playersLeft++;
            p1IsAlive = true;
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            playersLeft++;
            p2IsAlive = true;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            playersLeft++;
            p3IsAlive = true;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            playersLeft++;
            p4IsAlive = true;
        }
        otherDestroyer.playersLeft = playersLeft;

        
        
    }

    void SetRewardValue()
    {
        Debug.Log("Set Rewards Value");
        switch (playersLeft)
        {
            case 1:
                rewardValue = 1;
                break;
            case 2:
                rewardValue = -1;
                break;
            case 3:
                rewardValue = -1;
                break;
            case 4:
                rewardValue = -2;
                break;
        }
        if (roundsPlayed >= 20)
        {
            rewardValue++;
        }
        otherDestroyer.rewardValue = rewardValue;
    }

    void UpdateScore(PlayerScore score)
    {
        Debug.Log("Update Score: " + score);
        if (rewardValue == 0)
        {
            rewardValue++;
        }
        score.score += rewardValue;
        if (score.score < 0)
        {
            score.score = 0;
        }
        rewardValue++;
        otherDestroyer.rewardValue = rewardValue;
    }

    void ResetPowerUps()
    {
        if (GameStats.Player1)
        {
            p1Up.DisableAll();
        }
        if (GameStats.Player2)
        {
            p2Up.DisableAll();
        }
        if (GameStats.Player3)
        {
            p3Up.DisableAll();
        }
        if (GameStats.Player4)
        {
            p4Up.DisableAll();
        }
    }

    void Respawn()
    {
        spawnPositions = new List<Vector3>();

        switch (XboxCtrlrInput.XCI.GetNumPluggedCtrlrs())
        {
            case 1:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                break;
            case 2:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                break;
            case 3:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                break;
            case 4:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                break;
            default:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                break;
        }


        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 temp = spawnPositions[i];
            int randomIndex = Random.Range(i, spawnPositions.Count);
            spawnPositions[i] = spawnPositions[randomIndex];
            spawnPositions[randomIndex] = temp;
        }
        Debug.Log("Respawning!");
        if (GameStats.Player1)
        {
            player1.transform.position = spawnPositions[0];
            player1.transform.rotation = spawnPoint.rotation;
            player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (GameStats.Player2)
        {
            player2.transform.position = spawnPositions[1];
            player2.transform.rotation = spawnPoint.rotation;
            player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (GameStats.Player3)
        {
            player3.transform.position = spawnPositions[2];
            player3.transform.rotation = spawnPoint.rotation;
            player3.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (GameStats.Player4)
        {
            player4.transform.position = spawnPositions[3];
            player4.transform.rotation = spawnPoint.rotation;
            player4.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void UnAlivePlayer(PlayerScore ps)
    {
        Debug.Log("UnAlive Player: " + ps.playerNum);
        switch (ps.playerNum)
        {
            case 1:
                p1IsAlive = false;
                player1.SetActive(false);
                break;
            case 2:
                p2IsAlive = false;
                player2.SetActive(false);
                break;
            case 3:
                p3IsAlive = false;
                player3.SetActive(false);
                break;
            case 4:
                p4IsAlive = false;
                player4.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playersLeft > 1)
            {
                if (masterDestroyer)
                {
                    playersLeft--;
                    PlayerScore ps = other.GetComponent<PlayerScore>();
                    UpdateScore(ps);
                    UnAlivePlayer(ps);
                    otherDestroyer.playersLeft = playersLeft;
                    //other.gameObject.SetActive(false);
                }
                else
                {
                    otherDestroyer.playersLeft--;
                    PlayerScore ps = other.GetComponent<PlayerScore>();
                    otherDestroyer.UpdateScore(ps);
                    otherDestroyer.UnAlivePlayer(ps);
                    playersLeft = otherDestroyer.playersLeft;

                }
                
            }
        }
    }


}
