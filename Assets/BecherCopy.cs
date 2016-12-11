using UnityEngine;

public class BecherCopy : MonoBehaviour
{

    public GameObject GameobjectToCopy;

    // Use this for initialization
    void Start()
    {
        //TODO
       Instantiate(GameobjectToCopy, transform, false);

    }

}
