using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EndPlane : MonoBehaviour
{
    public Button main_BTN;
    public Button exit_BTN;

    private void Awake()
    {
        main_BTN.onClick.AddListener(MainClick);
        exit_BTN.onClick.AddListener(ExitClick);
    }

    public void MainClick()
    {
        UIManagement.Instance.OpenMainPlane();
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
