using TMPro;
using UnityEngine;

public class SpentObject : MonoBehaviour
{
    public TextMeshProUGUI expenseName;
    public TextMeshProUGUI expenseAmount;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditSpentObject(string spentName, string spentAmount)
    {
       expenseName.text = spentName;
        expenseAmount.text = "-"+spentAmount;
        Debug.Log("working");
    }
}
