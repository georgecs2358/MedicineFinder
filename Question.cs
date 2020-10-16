using System.Collections.Generic;

namespace DrugFinder
{
  class Question
  {
    public Question()
    {
      ChildQuestionList = new List<Question>();
      ResponseScores = new List<int>();
    }

    public List<Question> ChildQuestionList { get; set; }
    public string Title { get; set; }
    public List<int> ResponseScores { get; set; }
    public int Response { get; set; }

    public void ExportScores()
    {
      if (Response == 0)
      {
        Program.TotalDrugEffectScoreA += ResponseScores[0];
        Program.TotalDrugEffectScoreB += ResponseScores[1];
        Program.TotalDrugEffectScoreC += ResponseScores[2];
        Program.TotalDrugEffectScoreD += ResponseScores[3];
      } else if (Response == 1) {
        Program.TotalDrugEffectScoreA += ResponseScores[4];
        Program.TotalDrugEffectScoreB += ResponseScores[5];
        Program.TotalDrugEffectScoreC += ResponseScores[6];
        Program.TotalDrugEffectScoreD += ResponseScores[7];        
      }
    }
  }
}