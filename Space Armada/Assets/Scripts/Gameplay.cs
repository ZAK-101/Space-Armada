using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int rows;
    public int columns;
}

public enum spawnState
{
    SPAWNING, 
    WAITING, 
    COUNTING
}

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    public GameObject[] invaderPrefabs;

    public float invadersSpacing;
    public int prefabsCount;

    public List<Wave> waves;
    public Wave wave;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private spawnState state = spawnState.COUNTING;

    private void Awake()
    {

        instance = this;

    }

    void OnDestroy()
    {
        instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        wave.rows = 1;
        wave.columns = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!enemyIsAlive())
            {
                waveCompleted(wave);
                return;
            }

            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                Debug.Log("start round");
                StartCoroutine(spawnWave(waves[nextWave]));
                
            }
        }

        else
        {
            waveCountdown -= Time.deltaTime;
            Debug.Log(waveCountdown);
        }
    }

    void waveCompleted(Wave _wave)
    {
        Debug.Log("wave completed");

        state = spawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        wave.rows++;
        wave.columns++;

        if (wave.rows >= 6)
        {
            wave.rows = 6;
        }

        if (wave.columns >= 11)
        {
            wave.columns = 11;
        }

        waves.Add(new Wave { rows = wave.rows, columns = wave.columns });

        nextWave++;
    }

    bool enemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

        }

        return true;
    }

    IEnumerator spawnWave(Wave _wave)
    {
        state = spawnState.SPAWNING;

        spawnInvaders(_wave);
     
        state = spawnState.WAITING;
        
        yield break;
    }

    void spawnInvaders(Wave wave)
    {
        // used for instantiating the different types of enemies
        prefabsCount = 0;

        for (int row = 0; row < wave.rows; row++)
        {
            float width = invadersSpacing * (wave.columns - 1);
            float height = invadersSpacing * (wave.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3 (centering.x, centering.y + (row * invadersSpacing), 0.0f);

            // if the count is over the length of the 
            // array of the invader prefab, we reset the value
            // of the count
            if (prefabsCount >= invaderPrefabs.Length)
            {
                prefabsCount = 0;
            }

            for (int col = 0; col < wave.columns; col++)
            {
                GameObject invader = Instantiate(this.invaderPrefabs[prefabsCount], this.transform);
                Vector3 pos = rowPos;
                pos.x += col * invadersSpacing;
                invader.transform.localPosition = pos;
            }

            prefabsCount++;

        }
    }
}
