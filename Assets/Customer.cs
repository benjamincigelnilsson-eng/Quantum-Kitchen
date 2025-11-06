using UnityEngine;

public class Customer : MonoBehaviour, IInteractable
{
    public Dish chickenDish;         // dra in dina ScriptableObjects i Inspector
    public Dish octopusDish;

    public Dish wanted;              // vad kunden vill ha (slumpas)
    bool hasOrdered = false;         // har kunden beställt än?

    void Start()
    {
        // Välj slumpmässigt vad kunden vill ha (om inget redan är satt)
        if (wanted == null)
        {
            Dish[] options = new Dish[] { chickenDish, octopusDish };
            wanted = options[Random.Range(0, options.Length)];
        }
    }

    // Kallas när spelaren trycker E och står nära (från PlayerInteractor)
    public void Interact(GameObject playerGO)
    {
        var held = playerGO.GetComponent<HeldItem>(); // vad spelaren bär

        if (!hasOrdered)
        {
            hasOrdered = true;
            Debug.Log($"Kund beställer: {wanted.dishName}");
            // här kommer vi senare: visa bubblan
            return;
        }

        // Hit kommer vi när kunden väntar på mat
        if (held == null || !held.HasDish)
        {
            Debug.Log("Du håller ingen mat ännu.");
            return;
        }

        if (held.carried == wanted)
        {
            Debug.Log($"Rätt mat! {wanted.dishName}. Kunden går.");
            held.Clear();                 // spelaren lämnar ifrån sig maten
            Destroy(gameObject, 0.1f);    // kunden försvinner (sen kan spawner kalla nästa)
        }
        else
        {
            Debug.Log("Fel mat. Testa igen.");
        }
    }
}
