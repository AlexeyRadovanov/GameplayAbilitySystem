using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public static FloatingTextSpawner Instance { get; private set; }

    [SerializeField] private GameObject floatingTextPrefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Spawn(string text, Color color, Vector3 position)
    {
        var textObject = Instantiate(floatingTextPrefab, position, Quaternion.identity);
        var floatingText = textObject.GetComponent<FloatingText>();
        floatingText.Initialize(text, color);
    }
}
