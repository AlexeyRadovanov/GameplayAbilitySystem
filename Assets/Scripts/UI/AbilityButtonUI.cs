using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonUI : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Image icon;
    private AbilityManager abilityManager;
    private int abilityIndex;
    private float cooldownRemaining;
    private float cooldownTotal;
    private bool isOnCooldown;
    private Func<Vector3> getTargetPosition;

    void Awake()
    {
        fadeImage.fillAmount = 0f;
    }

    public void Initialize(int index, AbilityManager abilityManager, Func<Vector3> targetProvider)
    {
        abilityIndex = index;
        this.abilityManager = abilityManager;
        getTargetPosition = targetProvider;
        icon.sprite = abilityManager.GetAbilityIcon(index);

        abilityManager.OnAbilityActivated += HandleAbilityActivated;
    }

    void OnDestroy()
    {
        abilityManager.OnAbilityActivated -= HandleAbilityActivated;
    }

    void Update()
    {
        if (!isOnCooldown) return;

        cooldownRemaining = abilityManager.GetCooldownRemaining(abilityIndex);
        fadeImage.fillAmount = cooldownRemaining / cooldownTotal;

        if (cooldownRemaining <= 0f)
        {
            isOnCooldown = false;
            fadeImage.fillAmount = 0f;
        }
    }

    void HandleAbilityActivated(int index)
    {
        if (index != abilityIndex) return;
        StartCooldownVisual();
    }

    void StartCooldownVisual()
    {
        cooldownTotal = abilityManager.GetCooldownDuration(abilityIndex);
        cooldownRemaining = cooldownTotal;
        isOnCooldown = true;
    }

    public void OnClick()
    {
        abilityManager.TryActivate(abilityIndex, getTargetPosition());
    }
}
