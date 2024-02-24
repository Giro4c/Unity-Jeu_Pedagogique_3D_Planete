using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz
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
    
    public Quizz()
    {
        questions = Array.Empty<Question>();
        started = false;
    }
}
