using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ViewWallet : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _wallet.ChangeCount += ChangeText;
    }

    private void OnDisable()
    {
        _wallet.ChangeCount -= ChangeText;
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
