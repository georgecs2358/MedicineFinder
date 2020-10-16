using System.Collections.Generic;

namespace DrugFinder
{
  class QuestionTree
  {
    public QuestionTree()
    {
      Questions = new List<Question>();

      Question questionC = new Question
      { 
        Title="Is the patient hostile to medicine?",
        ResponseScores={3, 9, 5, 3, 9, 2, 4, 10},

        // Response=0 'YES, they are dubious about anything made in a lab.'
        // Response=1 would be 'NO, eager for treatment at all costs.'
        Response=0
      };

      Question questionB = new Question
      { 
        Title="What bothers the patient more, nausea/vomiting or stomach pain?",

        // These are unscientifically calculated but we will instead use
        // clinical trials data to calculate scientifically. They link the  
        // patient question response to the drug effect variables

        // Response=0 would be 'Nausea/vomiting' which gives PFS=5, 
        // time to treatment failure=5, Liver damage=6, Nausea=0
        // Response=1 'Stomach pain' gives ProgFreeSurvival=5, TTTF=5, 
        // Liver damage=0, Nausea=8
        ResponseScores={5, 5, 6, 0, 5, 5, 0, 8}, 
        Response=0
      };
      
      Question questionA = new Question
      { 
        ChildQuestionList = { questionB, questionC },
        Title="What is the patient's main aim from treatment?",
        ResponseScores={2, 8, 7, 2, 8, 3, 8, 10},

        // Response=0 'Improve my quality of life'
        // Response=1 'Eradicate the disease, be dedicated to chemotherapy.'
        Response=0
      };

      Questions.Add(questionA);
      Questions.Add(questionB);
      Questions.Add(questionC);

      // This code will be run once all questions have been asked
      for (int i=0; i<3; i++)
      {
        Program.NumberQuestionsAsked++;
        Questions[i].ExportScores();
      }
    }
    public List<Question> Questions { get; set; }
  }
}