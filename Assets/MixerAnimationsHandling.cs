using UnityEngine;

public class MixerAnimationsHandling : MonoBehaviour
{
    [SerializeField] MixerMachineBecher _machineBecher;

    Animator _animator;

    Color _lastColorThatFlowed;


    public Side Side;


    void Start()

    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void TriggerAnimation(Color color)
    {
       
        AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        bool isNotPlayingPouringAnim = currentAnimatorStateInfo.shortNameHash != Animator.StringToHash(MixerAnimParams.PourringLiquid.ToString());
        if (isNotPlayingPouringAnim)
        {
            _machineBecher.ChangeColorOfFlowingLiquid(color, Side);
            _lastColorThatFlowed = color;
            _animator.SetTrigger(MixerAnimParams.PourringLiquid.ToString());
            PlayerBecher playerBecher = MySceneManager.GetPlayerController().BecherHeld;

            playerBecher.EditBecher(ChemicalType.None);

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
        _machineBecher.SetNewBecher(_lastColorThatFlowed);
        _lastColorThatFlowed = Color.clear;
    }
}

enum MixerAnimParams
{
    PourringLiquid
}