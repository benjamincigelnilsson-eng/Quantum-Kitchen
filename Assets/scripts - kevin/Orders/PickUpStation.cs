using UnityEngine;

public class PickupStation : MonoBehaviour, IInteractable
{
    public Dish dishToGive; // sätt i Inspector (Chicken eller Octopus)

    public void Interact(GameObject playerGO)
    {
        var held = playerGO.GetComponent<HeldItem>();
        if (held == null) return;

        held.Take(dishToGive);
        Debug.Log("Du håller: " + dishToGive.dishName);
    }
}
