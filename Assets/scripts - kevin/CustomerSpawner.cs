using UnityEngine;
using System.Collections;

public class CustomerSpawner : MonoBehaviour
{
    [Header("Inställningar")]
    public GameObject customerPrefab;  // Dra in din Customer.prefab här
    public Transform spawnPoint;       // Dra in ett objekt där kunderna ska dyka upp
    public float spawnDelay = 2f;      // Paus mellan kunder (sekunder)

    private GameObject currentCustomer;
    private bool isSpawning = false;

    void Start()
    {
        SpawnNewCustomer();
    }

    void Update()
    {
        // Om ingen kund finns och vi inte redan håller på att spawna → skapa ny
        if (currentCustomer == null && !isSpawning)
        {
            StartCoroutine(SpawnAfterDelay());
        }
    }

    IEnumerator SpawnAfterDelay()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnDelay);
        SpawnNewCustomer();
        isSpawning = false;
    }

    void SpawnNewCustomer()
    {
        if (customerPrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("[Spawner] Saknar prefab eller spawn point!");
            return;
        }

        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("[Spawner] Spawnade ny kund: " + currentCustomer.name);
    }
}
