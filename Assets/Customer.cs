using UnityEngine;

public class Customer : MonoBehaviour, IInteractable
{
    [Header("Maträtter")]
    public Dish chickenDish;
    public Dish octopusDish;

    [Header("Utseende (sprites)")]
    public Sprite[] possibleSprites; // dra in 2–10 olika kundbilder här

    private Dish wanted;
    private bool hasOrdered = false;
    private bool gotFood = false;

    void Start()
    {
        // Slumpa sprite
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null && possibleSprites != null && possibleSprites.Length > 0)
            sr.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];

        // Slumpa beställning
        Dish[] options = { chickenDish, octopusDish };
        wanted = options[Random.Range(0, options.Length)];
    }

    public void Interact(GameObject playerGO)
    {
        var held = playerGO.GetComponent<HeldItem>();

        if (!hasOrdered) { hasOrdered = true; Debug.Log("[Customer] Beställer: " + wanted.dishName); return; }
        if (!gotFood)
        {
            if (held == null || !held.HasDish) { Debug.Log("[Customer] Du håller ingen mat."); return; }

            bool sameAsset = held.carried == wanted;
            bool sameName = held.carried != null && wanted != null && held.carried.dishName == wanted.dishName;

            if (sameAsset || sameName) { gotFood = true; held.Clear(); Destroy(gameObject, 0.5f); }
            else Debug.Log("[Customer] Fel mat. Ville ha: " + wanted.dishName);
        }
    }
}
