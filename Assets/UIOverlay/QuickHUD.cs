using UnityEngine;
using UnityEngine.UI;

public class QuickHUD : MonoBehaviour {
    public HorizontalLayoutGroup outputTarget;
    public Text outputPrefab;
    void Reset ()
    {
        outputTarget = this.gameObject.GetComponent<HorizontalLayoutGroup>();
    }

    public Text registerHudElement()
    {
        var t = Object.Instantiate(outputPrefab);
        t.transform.SetParent(outputTarget.transform, false);
        return t;
    }
}
