using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;

    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();

        NextQuestion();
    }

    private void NextQuestion()
    {
        m_quizUI.Construct(m_quizDB.GetRandom(),GiveAnswer);
    }

    private void GiveAnswer(obtionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    private IEnumerator GiveAnswerRoutine(obtionButton optionButton)
    {
        //if (m_audioSource.isPlaying)
        //    m_audioSource.Stop();

     //   m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        //m_audioSource.Play();

        yield return new WaitForSeconds(m_waitTime);

        if (optionButton.Option.correct)
            //Sumar propiedad de la opcion si es correcta n+1;
            NextQuestion();
        else
            //REiniciar juego o NextQuestion(); "Pasar a la siguiente pregunta"
            GameOver();

        NextQuestion();
    }

    private void GameOver()
    {

    }
}
