using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetValue(float current, float max)
    {
        fillImage.fillAmount = max > 0 ? current / max : 0f;
    }
}
