using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public PhotoPosition position;
    private SpriteRenderer sr;
    private bool _selected;

    public bool Selected
    {
        get => _selected;
        set {
            _selected = value;
            if (value)
            {
                sr.color = Color.gray;
            }
            else
            {
                sr.color = Color.white;                
            }
        }
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("CLick");
        Debug.Log(gameObject.name);

        if (position != null)
        {
            if (Selected)
            {
                Selected = false;                
                WorkflowManager.RemovePosition(position);
            }
            else
            {
                Selected = true;                
                WorkflowManager.AddPosition(position);
            }
        }
    }
}
