using UnityEngine;
using TMPro;

public class WellcomeScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField regoInput;

    public void BtnStart()
    {
        WorkflowManager.NewSession(regoInput.text);       
    }

}
