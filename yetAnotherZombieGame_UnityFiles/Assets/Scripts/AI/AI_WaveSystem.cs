using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AI_WaveSystem : MonoBehaviour {

    //Custom set in inspector
    public int initialWaveSize;
    public int waveSize;
    public float multiplerAmount;
    public List<Transform> spawnPoints;
    public GameObject Zombie_Prefab;
    public float timeToNextWave = 2;
    public float nextSpawnTime;
    public int initialSpawnAmont;
    public Text GUI_CurrentWave;
    public GameObject GUI_WaveCounter;
    public Text GUI_CounterText;
    //not editable in inspector but visible
    [SerializeField]
    int amountSpawned = 0;
    [SerializeField]
    int lastWaveSize = 0;
    [SerializeField]
    GameObject player;
    [SerializeField]
    bool waveInProgress = false;
    [SerializeField]
    int waveLevel = 1;
    [SerializeField]
    int roundKillCount;
    [SerializeField]
    float spawnTimer;
    [SerializeField]
    float waveTimer;

    float boastZombies = 10;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        waveSize = initialWaveSize;
        spawnTimer = nextSpawnTime;
        waveTimer = timeToNextWave;
    }

    void FixedUpdate()
    {
        if (waveInProgress)
        {
            GUI_CurrentWave.text = "Wave: " + waveLevel.ToString();
            waveTimer = timeToNextWave;
            roundKillCount = player.GetComponent<Character_Controller>().getKills() - lastWaveSize;
            spawnWave();
            if (roundKillCount >= waveSize)
            {
                waveInProgress = false;
                waveLevel++;
                amountSpawned = 0;
                roundKillCount = 0;
                lastWaveSize = lastWaveSize + waveSize;
                player.GetComponent<Character_Controller>().addScore(100);
                if(waveLevel > boastZombies)
                {
                    if (Zombie_Prefab.GetComponent<NavMeshAgent>().speed < 10)
                    {
                        Zombie_Prefab.GetComponent<NavMeshAgent>().speed++;
                    }
                    Zombie_Prefab.GetComponent<Health>().health = Zombie_Prefab.GetComponent<Health>().health + 10;
                    boastZombies = boastZombies + 10;
                }
            }
        }
        else
        {
            
            GUI_WaveCounter.SetActive(true);
            GUI_CounterText.text = ((int)waveTimer).ToString();
            waveTimer -= Time.deltaTime;
            if (waveTimer < 0)
            {
                waveInProgress = true;
                //Apply multipler then round to nears hole number(Unity always rounds down). Write own round instead quick casting
                waveSize = (int)(waveSize * multiplerAmount);
                initialSpawnAmont =(int)(initialSpawnAmont * multiplerAmount);
                GUI_WaveCounter.SetActive(false);
            }
        }
    }
    void spawnWave()
    {
        if (amountSpawned < waveSize)
        {
            if (amountSpawned < initialSpawnAmont)
            {
                bool spawned = false;
                if (!spawned)
                {
                    spawned = true;
                    GameObject zombie = Instantiate(Zombie_Prefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, spawnPoints[Random.Range(0, spawnPoints.Count)].rotation);
                    amountSpawned++;
                    Debug.Log("Spawned" + amountSpawned);
                }
            }
            else
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0)
                {
                    GameObject zombie = Instantiate(Zombie_Prefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, spawnPoints[Random.Range(0, spawnPoints.Count)].rotation);
                    spawnTimer = nextSpawnTime;
                    amountSpawned++;
                }
            }
        }
        else {}
    }
}
