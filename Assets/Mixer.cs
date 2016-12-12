using UnityEngine;

public class Mixer : MonoBehaviour
{


    [SerializeField] MixerMachineBecher _machineBecher;




    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    void LiquidFlowedToTheEnd()
    {
        Debug.Log("Liquid flowed to the end at  " + transform.parent.gameObject.name);
    }
}