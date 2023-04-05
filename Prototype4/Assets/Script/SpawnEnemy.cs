using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int waveNumber = 1;
    [SerializeField] private int enemyCount;

    //ref to enemy prefab
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private GameObject[] powerPrefab;
    private float SpawnRange = 9;

    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(waveNumber);
        PowerSpawn();

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (playerScript.isGameOver != true)
        {
            if (enemyCount == 0)
            {
                waveNumber++;
                Spawn(waveNumber);
                PowerSpawn();


            }
        }
        


    }

    void Spawn(int enemytoSpawn)
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        for (int i = 0; i < enemytoSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyIndex], SpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        }

    }


    void PowerSpawn()
    {
        int powerIndex = Random.Range(0, powerPrefab.Length);


        Instantiate(powerPrefab[powerIndex], SpawnPosition(), powerPrefab[powerIndex].transform.rotation);

    }

    private Vector3 SpawnPosition()
    {
        float xSpawn = Random.Range(-SpawnRange, SpawnRange);
        float zSpawn = Random.Range(-SpawnRange, SpawnRange);

        Vector3 SpawnPos = new Vector3(xSpawn, 0, zSpawn);
        return SpawnPos;
    }
}
