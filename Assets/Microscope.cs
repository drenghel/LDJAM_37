using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscope : MonoBehaviour {
    [SerializeField]private SpriteRenderer _overSpriteRenderer;


    //TODO should be a child class

    private void OnMouseOver()
    {
        _overSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSpriteRenderer.enabled = false;
    }


    void Start()
    {
        _overSpriteRenderer.enabled = false;

    }
}
