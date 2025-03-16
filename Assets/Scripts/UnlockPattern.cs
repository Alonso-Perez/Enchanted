using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPattern : MonoBehaviour
{
    public List<Button> nodos;
    private List<int> usarPatron=new List<int>();

    //Ejemplo 1 de patron
    private List<int> patronCorrecto1 = new List<int>{0,1,2,4,7};

    private bool isDrawing = false;

    void Start(){
        for(int i=0; i<nodos.Count;i++){
            int indice=i;
            nodos[i].onClick.AddListener(()=>OnNodeSelected(indice));
        }
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            usarPatron.Clear();
            isDrawing=true;
        }

        if(Input.GetMouseButtonUp(0) && isDrawing){
            isDrawing=false;
            CheckPattern();
        }
    }

    void OnNodeSelected(int indiceNodo){
        if(isDrawing && !usarPatron.Contains(indiceNodo)){
            usarPatron.Add(indiceNodo);
            HighlightNode(indiceNodo, true);
        }
    }

    void CheckPattern(){
        if(usarPatron.Count != patronCorrecto1.Count){
            Debug.Log("Patrón incorrecto");
            ResetPattern();
            return;
        }

        for(int i=0; i<patronCorrecto1.Count; i++){
            if(usarPatron[i]!=patronCorrecto1[i]){
                Debug.Log("Patron Incorrecto");
                ResetPattern();
                return;
            }
        }

        Debug.Log("Patron correcto");
    }

    void ResetPattern(){
        usarPatron.Clear();
        foreach(Button node in nodos){
            HighlightNode(nodos.IndexOf(node), false);
        }
    }

    void HighlightNode(int indice, bool activo){
        Color newColor = activo ? Color.green : Color.white;
        nodos[indice].GetComponent<Image>().color=newColor;
    }

}
