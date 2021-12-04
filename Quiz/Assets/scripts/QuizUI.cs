using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour {

    [SerializeField] private Text m_quesition = null;
    [SerializeField] private List<obtionButton> m_buttonList = null;

    public void Construct(question q, Action<obtionButton> callback)
    {
        m_quesition.text = q.text;
        for(int n = 0; n<m_buttonList.Count; n++)
        {
            m_buttonList[n].Construct(q.options[n], callback);
        }
    }
}
