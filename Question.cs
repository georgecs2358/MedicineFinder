using System.Collections.Generic;

namespace DrugFinder
{
  class Question
  {
    public string Title { get; set; }
    public int[,] ResponseScores { get; set; }
    public int Response { get; set; }

    // This method exports the scores
    public void ExportScores()
    {
      if (Response == 0)
      {
        for (int i=0; i<8; i++)
        {
          Program.PatientVariableTotals[i] += ResponseScores[0,i];
        }
      } 
      else if (Response == 1) 
      {
        for (int i=0; i<8; i++)
        {
          Program.PatientVariableTotals[i] += ResponseScores[1,i];
        }      
      }
    }
  }
}