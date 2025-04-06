using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool active = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            menu.SetActive(active);
        }
    }
}