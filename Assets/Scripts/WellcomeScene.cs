using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WellcomeScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField regoInput;
    [SerializeField] private Button btnStart;

    private void Start()
    {
        btnStart.interactable = false;
    }

    public void BtnStart()
    {
        WorkflowManager.NewSession(regoInput.text);       
    }

    public void RegoChanged()
    {
        btnStart.interactable = !string.IsNullOrWhiteSpace(regoInput.text);
    }

}
