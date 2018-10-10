using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2 : MonoBehaviour {

void Update () {
if(Input.anyKeyDown)
{
SceneManager.LoadScene("Level02");
}
}
}
