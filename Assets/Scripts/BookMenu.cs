using UnityEngine;

public class BookMenu : MonoBehaviour
{
    [SerializeField] GameObject bookMenu;

    public void Book(){
        bookMenu.SetActive(true);
        Time.timeScale=0;
    }

    public void Return(){
        bookMenu.SetActive(false);
        Time.timeScale=1;
    }
}
