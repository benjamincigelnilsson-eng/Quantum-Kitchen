using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderBubbleUI : MonoBehaviour
{
    public Button chickenBtn;
    public Button octopusBtn;
    public TextMeshProUGUI hintText;

    private HeldItem heldItem; // kopplas när spelaren interagerar

    void Awake()
    {
        gameObject.SetActive(false); // döljer bubblan i början
    }

    public void Show(HeldItem playerHeld)
    {
        heldItem = playerHeld;
        gameObject.SetActive(true);
        if (hintText != null)
            hintText.text = "Välj mat att hålla i handen";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetupButtons(Dish chickenDish, Dish octopusDish)
    {
        chickenBtn.onClick.RemoveAllListeners();
        octopusBtn.onClick.RemoveAllListeners();

        chickenBtn.onClick.AddListener(() => Pick(chickenDish));
        octopusBtn.onClick.AddListener(() => Pick(octopusDish));
    }

    private void Pick(Dish dish)
    {
        if (heldItem == null) return;

        heldItem.Take(dish);
        if (hintText != null)
            hintText.text = "Du håller: " + dish.dishName;

        // Bubblan kan stängas direkt om ni vill
        // Hide();
    }
}
