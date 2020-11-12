using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishScene : MonoBehaviour
{
    [SerializeField] private TMP_Text txtRego;

    private void Start()
    {
        txtRego.text = WorkflowManager.session.Rego;

        WorkflowManager.Persist();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
