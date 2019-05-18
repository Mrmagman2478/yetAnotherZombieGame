using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //not editable in inspector but visible
    [SerializeField]
    int amountSpawned = 0;
    [SerializeField]
    int lastWaveSize = 0;
    [SerializeField]
    GameObject player;
    [SerializeField]
    bool waveInProgress = true;
    [SerializeField]
    int waveLevel = 1;
    [SerializeField]
    int roundKillCount;
    [SerializeField]
    float spawnTimer;
    [SerializeField]
    float waveTimer;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        waveSize = initialWaveSize;
        spawnTimer = nextSpawnTime;
        waveTimer = timeToNextWave;

    }

    void FixedUpdate()
    {
        GUI_CurrentWave.text = "Wave: "+ waveLevel.ToString();
        if (waveInProgress)
        {
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
            }
        }
        else
        {
            waveTimer -= Time.deltaTime;
            if(waveTimer <= 0)
            {
                waveInProgress = true;
                //Apply multipler then round to nears hole number(Unity always rounds down). Write own round instead quick casting
                waveSize = (int)(waveSize * multiplerAmount);
                initialSpawnAmont =(int)(initialSpawnAmont * multiplerAmount);
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
