using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishScene : MonoBehaviour
{
    [SerializeField] private TMP_Text txtRego;
    [SerializeField] private GameObject toast;
    [SerializeField] private GameObject label;

    private void Start()
    {
        toast.SetActive(false);
        txtRego.text = WorkflowManager.session.Rego;
        
    }

    public void ButtonSubmit()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        toast.SetActive(true);
        label.SetActive(false);
        yield return new WaitForSeconds(5f);
        WorkflowManager.Persist();

    }

}
