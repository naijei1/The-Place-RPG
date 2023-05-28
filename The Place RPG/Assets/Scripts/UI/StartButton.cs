using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    [SerializeField] private Button primaryButton;
    // Start is called before the first frame update
    void Start()
    {
        primaryButton.Select();
    }
}
