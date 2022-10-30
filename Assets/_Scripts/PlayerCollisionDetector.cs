using _Scripts;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private CloneSpawner _cloneSpawner;
    private void Awake() => _cloneSpawner = GetComponent<CloneSpawner>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MathGate")) DoMath(other.GetComponent<MathGateController>());
        else if (other.CompareTag("PassiveClone"))
        {
            other.GetComponent<PassiveCloneController>().SetClone();
        }
        else
        {
            GameManager.Instance.IsLastFightStarted = true;
            GameManager.Instance.TriggerClones();
        }
    }
    private void DoMath(MathGateController mathGate)
    {
        switch (mathGate.Math)
        {
            case Math.Sum:
                _cloneSpawner.CreateClone(mathGate.Number, false);
                break;
            case Math.Sub:
                _cloneSpawner.CreateClone(mathGate.Number * -1, true);
                break;
            case Math.Multiply:
                _cloneSpawner.CreateClone(GameManager.Instance.ActiveCloneAmount * mathGate.Number, false);
                break;
            case Math.Divide:
                _cloneSpawner.CreateClone(GameManager.Instance.ActiveCloneAmount / mathGate.Number, true);
                break;
        }
    }
}