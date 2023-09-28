using Game.Items;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private BaseHealthComponent _healthComponent;
    [SerializeField] private PlayerManaComponent _manaComponent;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private Bar _healthBar = null;
    [SerializeField] private Bar _manaBar = null;
    [SerializeField] private MovePanel _movePanel;
    [SerializeField] private Inventory _inventory;

    private static HUD _instance;

    public static HUD Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    public void CreateIvnerotryItem(InventoryItem item)
    {
        _inventory.CreateIvnerotryItem(item);
    }

    public void ShowLosePanel()
    {
        _movePanel.ShowPanel();
    }

    private void UpdateHealthBar(float value, float maxValue)
    {
        _healthBar.ChangeValueProgress(value, maxValue);

    }

    private void UpdateManaBar(int value, int maxValue)
    {
        _manaBar.ChangeValueProgress(value, maxValue);
    }

    private void OnEnable()
    {
        _healthComponent.OnHealthNull += ShowLosePanel;
        _healthComponent.OnChangeHP += UpdateHealthBar;
        _manaComponent.OnChangeMana += UpdateManaBar;

    }

    private void OnDisable()
    {
        _healthComponent.OnHealthNull -= ShowLosePanel;
        _healthComponent.OnChangeHP -= UpdateHealthBar;
        _manaComponent.OnChangeMana -= UpdateManaBar;

    }
}
