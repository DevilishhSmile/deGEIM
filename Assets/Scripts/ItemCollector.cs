using System.Collections;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;

    [SerializeField] private TextMeshProUGUI fruitsCountText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            fruits++;
            UpdateFruitsCountText();
        }
    }

    private void UpdateFruitsCountText()
    {
        if (fruitsCountText != null)
        {
            fruitsCountText.text = "Fruits: " + fruits.ToString();
        }
    }
}
