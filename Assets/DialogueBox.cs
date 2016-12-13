using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] Text _text;


    // Use this for initialization
    void Start()
    {
        HideDialogue();
        //SetDialogue("Hey new guys ! :D");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShowDialogue()
    {
        Debug.Log("Showing dialogue");

        GetComponent<Image>().enabled = true;
        _text.enabled = true;
    }

    void HideDialogue()
    {
        Debug.Log("Hiding dialogue");

        GetComponent<Image>().enabled = false;
        _text.enabled = false;
    }

    public void SetDialogue(string s)
    {
        _text.text = s;
    }


    public void DialogueActivate(float forSec = 5, float inSec = 0)
    {
        CancelInvoke();
        Invoke("ShowDialogue", inSec);
        Invoke("HideDialogue", forSec);
    }
}