using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz : MonoBehaviour
{
    public Question[] questions { get; private set; }
    public bool started { get; set; }

    public Quizz(Question[] questions, bool started)
    {
        this.questions = questions;
        this.started = started;
    }

    public Quizz(Question[] questions)
    {
        this.questions = questions;
        started = false;
    }
}
