using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private PhotoPosition position;
    private SpriteRenderer sr;

    public bool Selected = false;

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
                sr.color = Color.white;
                WorkflowManager.RemovePosition(position);
            }
            else
            {
                Selected = true;
                sr.color = Color.gray;
                WorkflowManager.AddPosition(position);
            }
        }
    }
}
