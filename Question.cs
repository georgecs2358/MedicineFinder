using System.Collections.Generic;

namespace DrugFinder
{
  class Question
  {
    public string Title { get; set; }
    public string[] ResponseText { get; set; }
    public int[,] ResponseScores { get; set; }
    public int Response { get; set; }

    // This check that the user entered a valid response to this question
    // TODO: Check this against a specific property of the question
    public bool ValidateResponse(int response)
    {
      if (response >= 0 && response < ResponseText.Length)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // This method exports the correct scores, of the response that was selected
    public void ExportScores()
    {
      for (int i=0; i<Program.PatientVariableTotals.Length; i++)
      {
        Program.PatientVariableTotals[i] += ResponseScores[Response,i];
      }
    }
  }
}