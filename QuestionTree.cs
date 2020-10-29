using System.Collections.Generic;

namespace DrugFinder
{
  class QuestionTree
  {
    public QuestionTree()
    {
      Questions = new List<Question>();

      Questions.Add(new Question
      { 
        Title="What is the patient's main aim from treatment?",
        ResponseScores = new int[2,8]
        {
          {2, 8, 7, 2, 1, 1, 1, 1}, 
          {8, 3, 8, 10, 1, 1, 1, 1},
        },

        // Response=0 'Improve my quality of life'
        // Response=1 'Eradicate the disease, be dedicated to chemotherapy.'
        Response=1
      });

      Questions.Add(new Question
      { 
        Title="What is more damaging to the patient, nausea/vomiting or stomach pain?",

        // These are unscientifically calculated but we will instead use
        // clinical trials data to calculate scientifically. They link the  
        // patient question response to the drug effect variables

        ResponseScores = new int[2,8]
        {
          {5, 5, 6, 0, 1, 1, 1, 1}, 
          {5, 5, 0, 8, 1, 1, 1, 1}, 
        },

        // Response=0 would be 'Nausea/vomiting' which gives PFS=5, 
        // time to treatment failure=5, Liver damage=6, Nausea=0
        // Response=1 'Stomach pain' gives ProgFreeSurvival=5, TTTF=5, 
        // Liver damage=0, Nausea=8
        Response=0
      });

      Questions.Add(new Question
      { 
        Title="How enthusiastic is the patient about treatment?",
        ResponseScores = new int[2,8]
        {
          {3, 9, 5, 3, 1, 1, 1, 1}, 
          {9, 2, 4, 10, 1, 1, 1, 1}
        },

        // Response=0 'Not very, aims for a quick treatment effect'
        // Response=1 would be 'Willing to endure a longer treatment'
        Response=0
      });

      Questions.Add(new Question
      {
        Title="What symptoms bother the patient more, shortness of breath or liver impairment?",
        ResponseScores = new int[2,8]
        {
          {1, 1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 1, 1, 1, 1, 1}
        }
      });

      Questions.Add(new Question{
        Title="Does the patient suffer from any of the following allergies or pre-existing conditions?",
        ResponseScores = new int[2,8]
        {
          {1, 1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 1, 1, 1, 1, 1}
        },
        Response=0
      });

      Questions.Add(new Question{
        Title="What stage is the cancer at?",
        ResponseScores = new int[2,8]
        {
          {1, 1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 1, 1, 1, 1, 1}
        },
        Response=0
      });

      // This code will be run once all questions have been asked
      for (int i=0; i<Questions.Count; i++)
      {
        Program.NumberQuestionsUsed++;
        Questions[i].ExportScores();
      }
    }
    public List<Question> Questions { get; set; }
  }
}