using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    // Start is called before the first frame update
    public MoleScript molescript;
    public BoxCollider moleCollider;
    void Start()
    {
        molescript = GetComponentInChildren<MoleScript>();
    }

    public void TriggerMoleHide()
    {
        molescript.OnMoleHideAnimationFinished(this);
        moleCollider.enabled = false;
    }
    public void TriggerMoleShow()
    {
        molescript.OnMoleShowAnimationFinished(this);
        moleCollider.enabled = true;
    }
}
