using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [Header("Inställningar")]
    public GameObject[] customerPrefabs;   // lägg 2–3 olika Customer-prefabs här
    public Transform spawnPoint;           // var de dyker/spawnar upp
    public float spawnDelay = 2f;          // paus mellan kunder (sekunder)

    private GameObject currentCustomer;
    private float timer = 0f;

    void Start()
    {
        SpawnNewCustomer();
    }

    void Update()
    {
        // Vänta tills kunden är borta, räkna upp tid, spawna ny efter delay
        if (currentCustomer == null)
        {
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                SpawnNewCustomer();
                timer = 0f;
            }
        }
    }

    void SpawnNewCustomer()
    {
        if (spawnPoint == null || customerPrefabs == null || customerPrefabs.Length == 0)
        {
            Debug.LogWarning("[Spawner] Saknar spawnPoint eller customerPrefabs.");
            return;
        }

        int i = Random.Range(0, customerPrefabs.Length);
        currentCustomer = Instantiate(customerPrefabs[i], spawnPoint.position, Quaternion.identity);
        Debug.Log("[Spawner] Spawnade: " + customerPrefabs[i].name);
    }
}
