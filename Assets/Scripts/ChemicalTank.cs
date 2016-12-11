using UnityEngine;

public class ChemicalTank : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _overSprite;

    // Use this for initialization
    void Start()
    {
        _overSprite.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        //Debug.Log("Hey  a mouse is over " + transform.parent.gameObject.name);
    }

    private void OnMouseEnter()
    {
        _overSprite.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSprite.enabled = false;

    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Hey  someonetried to take some juice from  " + transform.parent.gameObject.name);

    }







}
