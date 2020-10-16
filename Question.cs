using System.Collections.Generic;

namespace DrugFinder
{
  class Question
  {
    public Question()
    {
      ChildQuestionList = new List<Question>();
    }

    public List<Question> ChildQuestionList { get; set; }
    public string Title { get; set; }
    public int[,] ResponseScores { get; set; }
    public int Response { get; set; }

    public void ExportScores()
    {
      if (Response == 0)
      {
        Program.TotalDrugEffectScoreA += ResponseScores[0,0];
        Program.TotalDrugEffectScoreB += ResponseScores[0,1];
        Program.TotalDrugEffectScoreC += ResponseScores[0,2];
        Program.TotalDrugEffectScoreD += ResponseScores[0,3];
      } else if (Response == 1) {
        Program.TotalDrugEffectScoreA += ResponseScores[1,0];
        Program.TotalDrugEffectScoreB += ResponseScores[1,1];
        Program.TotalDrugEffectScoreC += ResponseScores[1,2];
        Program.TotalDrugEffectScoreD += ResponseScores[1,3];        
      }
    }
  }
}