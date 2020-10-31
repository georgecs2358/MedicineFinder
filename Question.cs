using System.Collections.Generic;

namespace DrugFinder
{
  class Question
  {
    public string Title { get; set; }
    public int[,] ResponseScores { get; set; }
    public int Response { get; set; }

    // This check that the user entered a valid response to this question
    // TODO: Check this against a specific property of the question
    public bool ValidateResponse(int response)
    {
      if (response > 0 && response < 5)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

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