using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossUI : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
