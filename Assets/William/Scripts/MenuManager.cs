using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Code.Scripts.Managers;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject cursorPrefab;
    [SerializeField] private Vector3[] buttonLocations;
    [SerializeField] private Button[] buttons;
    [SerializeField] private int columsNum; //how many colum does the button layout have, this makes it psudo array. default 1
    private int cursorLocation;
    private int buttonsLength;

    // Start is called before the first frame update
    void Start()
    {
        cursorLocation = 0;
        cursorPrefab.transform.localPosition = buttonLocations[cursorLocation];
        buttonsLength = buttons.Length;
        if (buttonsLength != buttonLocations.Length)
        {
            Debug.Log("Error, buttonLocations and buttons need to match");
        }
    }

    public void HandleConfirm()
    {
        buttons[cursorLocation].onClick.Invoke();
        GameManager.Instance.GameUnpause();
    }

    public void HandleSelect(Vector2 inputVector)
    {
        Debug.Log(inputVector);
        if(inputVector.x > 0.7f)
        {
            if (columsNum > 1)
            {
                if (cursorLocation < buttonsLength -1)
                {
                    cursorLocation++;
                }   
            }
        }else if (inputVector.x < -0.7f)
        {
            if (columsNum > 1)
            {
                if (cursorLocation > 0)
                {
                    cursorLocation--;
                }          
            }
        } 
        
        if (inputVector.y < -0.7f)
        {
            if (cursorLocation + columsNum < buttonsLength)
            {
                cursorLocation += columsNum;
            }
        } else if (inputVector.y > 0.7f)
        {
            if (cursorLocation - columsNum >= 0)
            {
                cursorLocation -= columsNum;
            }
        }

        cursorPrefab.transform.localPosition = buttonLocations[cursorLocation];
    }

    public void CloseGUI()
    { 
        this.gameObject.SetActive(false);
    }

    public void SceneChangeMainMenu(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void SceneChange(int sceneNum)
    { 
        GameManager.Instance.ChangeScene(sceneNum);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
