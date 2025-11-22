using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int startingBudget;


    private int currentSavings;


    public GameObject spentObject;


    [Header("Container")]
    public GameObject containerObject;
    public GameObject addExpenseWindow;
    public GameObject todayExpenseObject;

    [Header("Input Fields")]
    public TMP_InputField expenseName;
    public TMP_InputField expenseAmount;
    public TMP_InputField date;

    


    void Start()
    {
        date.text = DateTime.Now.ToString("dd/MM/yyyy");
        Debug.Log(DateTime.Now.ToString("dd/MM/yyyy"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExpense()
    {
        
        addExpenseWindow.SetActive(true);


    }

    public void SaveExpense()
    {
        bool canSave = true;

        IsValidDate(date.text);

        GameObject currentSpentObject = Instantiate(spentObject, containerObject.transform);
        currentSpentObject.GetComponent<SpentObject>().EditSpentObject(expenseName.text, expenseAmount.text);
        addExpenseWindow.SetActive(false);
        expenseName.text = "";
        expenseAmount.text = "";
        date.text = DateTime.Now.ToString("dd/MM/yyyy");
    }

    public static bool IsValidDate(string input)
    {
        string format = "dd-MM-yyyy";
        DateTime parsedDate;

        // Try to parse with exact format
        bool isValid = DateTime.TryParseExact(
            input,
            format,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out parsedDate
        );

        if (!isValid)
            return false;

        // Strict month range check
        if (parsedDate.Month < 1 || parsedDate.Month > 12)
            return false;

        return true; // everything is correct
    }
}
