using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour {

    [SerializeField] private List<question> m_questionList = null;

    private List<question> m_backup = null;
    //Colocar contador de opciones correctas

    private void Awake()
    {
        m_backup = m_questionList.ToList();
    }

    public question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
            RestoreBackUp();
        
        int Index = Random.Range(0, m_questionList.Count);

        if (!remove)
            return m_questionList[Index];

        question q = m_questionList[Index];
        m_questionList.RemoveAt(Index);

        return q;
    }

    private void RestoreBackUp()
    {
        m_questionList = m_backup.ToList();
    }
}
