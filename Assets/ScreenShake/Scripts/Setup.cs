using UnityEngine;

public class Setup : MonoBehaviour
{
    public UnityEngine.UI.Button _button;
    public Rustic.ScreenShake _screenShake;

    void Start () {
	_button.onClick.AddListener(() => { Instantiate(_screenShake); });
    }
}
