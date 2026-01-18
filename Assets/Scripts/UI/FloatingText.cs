using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Text;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    public void Initialize(string text, Color color)
    {
        TMP_Text.text = text;
        TMP_Text.color = color;
    }

    void Update()
    {
        transform.position += Vector3.up *speed * Time.deltaTime;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0) Destroy(this.gameObject);
    }
}