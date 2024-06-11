using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlatformTextDisplay : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        string platformInfo = "This project is running ";
#if UNITY_EDITOR
        platformInfo += "in the editor";
#elif UNITY_WEBGL
        platformInfo += "on the Web"
#else
        platformInfo += "as a build";
#endif

        text.text = platformInfo;
    }
}