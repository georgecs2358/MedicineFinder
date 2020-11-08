using System.Collections.Generic;

namespace DrugFinder
{
  class QuestionBank
  {
    public QuestionBank()
    {
      Questions = new List<Question>();

      // Q1
      Questions.Add(new Question
      { 
        Title="What is the patient's main aim from treatment?",
        ResponseText = new string[2]
        {
          "(0) Improve their quality of life",
          "(1) Eradicate the disease at all costs, patient is dedicated to chemo"
        },
        ResponseScores = new int[2,9]
        {
          {7, 10, 1, 5, 2, 2, 2, 3, 3}, 
          {3, 0, 9, 5, 8, 8, 8, 7, 7},
        }
      });

      // Q2
      Questions.Add(new Question
      {
        Title="Is the patient likely to discontinue treatment?",
        ResponseText = new string[2]
        {
          "(0) Yes, it is likely based on their side effect profile and attitude",
          "(1) No, this is not likely in this case"
        },
        ResponseScores = new int[2,9]
        {
          {2, 10, 2, 5, 6, 8, 0, 3, 5}, 
          {8, 0, 8, 5, 5, 3, 10, 7, 5},
        }
      });

      // Q3
      Questions.Add(new Question
      { 
        Title="How enthusiastic is the patient about treatment?",
        ResponseText = new string[2]
        {
          "(0) Quite enthusiastic, willing to endure a longer treatment",
          "(1) Not enthusiastic, their aim is a quick treatment effect"
        },
        ResponseScores = new int[2,9]
        {
          {10, 3, 10, 7, 6, 8, 7, 7, 5}, 
          {0, 7, 2, 5, 5, 3, 3, 3, 5}
        }
      });

      // Q4
      Questions.Add(new Question
      {
        Title="Does the patient suffer from any allergies or preexisting conditions?",
        ResponseText = new string[5]
        {
          "(0) Patient has drug allergies",
          "(1) Patient has common allergies e.g. food, animals",
          "(2) Patient has a major lung condition e.g. cystic fibrosis, emphysema",
          "(3) Patient has a minor lung condition e.g. athsma",
          "(4) None"
        },
        ResponseScores = new int[5,9]
        {
          {9, 2, 4, 4, 0, 0, 1, 5, 1}, 
          {7, 6, 5, 5, 2, 2, 5, 5, 3},
          {3, 9, 8, 4, 3, 3, 4, 5, 6},
          {8, 5, 6, 5, 2, 2, 5, 5, 4},
          {10, 5, 4, 4, 8, 8, 10, 5, 4}
        }
      });

      // Q5
      Questions.Add(new Question{
        Title="What stage is the cancer at?",
        ResponseText = new string[4]
        {
          "(0) Grade 1",
          "(1) Grade 2",
          "(2) Grade 3",
          "(3) Grade 4"
        },
        ResponseScores = new int[4,9]
        {
          {7, 4, 1, 3, 10, 0, 2, 4, 0},
          {8, 6, 4, 4, 7, 3, 3, 5, 4},
          {9, 8, 7, 5, 3, 7, 4, 6, 6},
          {10, 10, 10, 6, 0, 10, 5, 7, 10}
        }
      });

      // Q6
      Questions.Add(new Question
      { 
        Title="What is more damaging to the patient, nausea/vomiting or stomach pain?",
        ResponseText = new string[2]
        {
          "(0) Nausea/vomiting",
          "(1) Stomach pain"
        },
        ResponseScores = new int[2,9]
        {
          {5, 5, 5, 5, 0, 8, 5, 6, 5}, 
          {5, 5, 5, 5, 8, 3, 5, 0, 5}, 
        }
      });

      // Q7
      Questions.Add(new Question
      {
        Title="What symptoms bother the patient more, shortness of breath or liver impairment?",
        ResponseText = new string[2]
        {
          "(0) Shortness of breath",
          "(1) Liver impairment"
        },
        ResponseScores = new int[2,9]
        {
          {5, 5, 5, 5, 2, 6, 5, 2, 5},
          {5, 5, 5, 5, 6, 2, 5, 6, 5}
        }
      });

      // Q8
      Questions.Add(new Question{
        Title="Would the patient better tolerate a range of grade 3/4 or a grade 5 side-effect?",
        ResponseText = new string[2]
        {
          "(0) Combination of grade 3/4 side-effects",
          "(1) Single grade 5 side-effect"
        },
        ResponseScores = new int[2,9]
        {
          {6, 3, 6, 5, 10, 0, 5, 6, 6},
          {4, 7, 8, 5, 0, 10, 5, 4, 4}
        }
      });
    }
    
    public List<Question> Questions { get; set; }

    // This code will be run once all questions have been asked
    public void CalculateScores()
    {
      for (int i=0; i<Questions.Count; i++)
      {
        Questions[i].ExportScores();
      }
    }
  }
}