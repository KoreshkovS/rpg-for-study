using UnityEngine;

public class MovePanel : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isShowed = false;

    public void ShowPanel()
    {
        _animator.SetBool("IsShowed", true);
    }
    public void HidePanel()
    {
        _animator.SetBool("IsShowed", false);
       
    }

    public void Show()
    {
        if (_isShowed)
        {
            _animator.SetBool("IsShowed", false);
            _isShowed = false;
        }
        else
        {
            _animator.SetBool("IsShowed", true);
            _isShowed = true;
        }

    }
}
