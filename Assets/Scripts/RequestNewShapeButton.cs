using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class RequestNewShapeButton : MonoBehaviour
{
    public int numberOfRequest = 3;
    public TextMeshProUGUI numberText;

    private int _currentNumberOfRequests;
    private Button _button;
    private bool _isLocked;

    void Start()
    {
        _currentNumberOfRequests = numberOfRequest;
        numberText.text = _currentNumberOfRequests.ToString();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonDown);
        UnLock();
    }

    private void OnButtonDown()
    {
        if(_isLocked == false)
        {
            _currentNumberOfRequests--;
            GameEvent.RequestNewShapes();
            GameEvent.CheckIfPlayerLost();

            if(_currentNumberOfRequests <= 0)
            {
                Lock();
            }

            numberText.text = _currentNumberOfRequests.ToString();
        }
    }

    private void Lock()
    {
        _isLocked = true;
        _button.interactable = false;
        numberText.text = _currentNumberOfRequests.ToString();
    }

    private void UnLock()
    {
        _isLocked = false;
        _button.interactable = true;
    }
}

