using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Image _fill;

    public void ChangeValueProgress(float value, float maxValue) // всі методи робляться публічними?
    {
        _fill.fillAmount = value / maxValue;

    }
}
