using UnityEngine;

public class Mixer : MonoBehaviour
{


    [SerializeField] MixerMachineBecher _machineBecher;

    Animator _animator;



    // Use this for initialization
    void Start()

    {
        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TriggerAnimation()
    {
        AnimatorStateInfo currentAnimatorStateInfo= _animator.GetCurrentAnimatorStateInfo(0);
        if (currentAnimatorStateInfo.shortNameHash != Animator.StringToHash(MixerAnimParams.PourringLiquid.ToString()))
        {

            _animator.SetTrigger(MixerAnimParams.PourringLiquid.ToString());
        }
        else
        {
            //TODO Better Feedback and blocking clikin maybe ?
            Debug.LogError("The liquid is still pourring please wait !");
        }
    }



    void LiquidFlowedToTheEnd()
    {
        Debug.Log("Liquid flowed to the end at  " + transform.parent.gameObject.name);
    }
}

enum MixerAnimParams
{
    PourringLiquid
}