using UnityEngine;

public class MixerAnimationsHandling : MonoBehaviour
{
    [SerializeField] MixerMachineBecher _machineBecher;

    Animator _animator;


    void Start()

    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void TriggerAnimation()
    {
        AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
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

    //used in animator
    void LiquidFlowedToTheEnd()
    {
        Debug.Log("Liquid flowed to the end at  " + transform.parent.gameObject.name);
    }
}

enum MixerAnimParams
{
    PourringLiquid
}