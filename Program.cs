using System;

namespace DrugFinder
{
  class Program
  {
    // Represents the patient's desired score for:
    // [0] Progression-free survival
    // [1] Time to treatment failure
    // [2] Liver impairment
    // [3] Nausea
    // [4] Time to progression
    // [5] Overall survival
    // [6] Kidney impairment
    // [7] Acne, diarrohea, sore mouth, sore nails
    public static int[] PatientVariableTotals { get; set; } = new int[8];

    private static Drug[] Drugs = new Drug[4];

    // An object which stores a list of questions, exports the response of these
    // questions
    private static QuestionBank QuestionBank;

    // The total number of questions asked, used to correctly compare the
    // patient's scores with the scientific score for each drug
    private static int NumberAsked = 0;

    static void Main(string[] args)
    {
      Initialise();

      while (NumberAsked < 10)
      {
        Console.WriteLine(QuestionBank.Questions[NumberAsked].Title);
        Console.WriteLine("Please enter (1) option1, (2) option(2)");

        int response;
        do {
          response = Convert.ToInt32(Console.ReadKey());
          QuestionBank.Questions[NumberAsked].Response = response;
        } while (
          !QuestionBank.Questions[NumberAsked].ValidateResponse(response)
        );
        NumberAsked++;
      }

      QuestionBank.CalculateScores();

      Console.Write("\n---------------------------------------------------\n");
      Console.WriteLine(
        FindBestDrug() + " is the best treatment for this patient."
      );
      Console.Write("---------------------------------------------------\n");
    }

    static void Initialise()
    {
      // This will always be initialised at startup; contains the logic code
      // behind asking questions
      QuestionBank = new QuestionBank();
      Drugs[0] = new Drug(
        "GEFETINIB",
        new int[] {3, 9, 5, 3, 1, 1, 1, 1}
      );
      Drugs[1] = new Drug(
        "AFATINIB",
        new int[] {9, 3, 4, 10, 1, 1, 1, 1}
      );
      Drugs[2] = new Drug(
        "OSIMERTINIB",
        new int[] {1, 1, 1, 1, 1, 1, 1, 1}
      );
      Drugs[3] = new Drug(
        "ERLOTINIB",
        new int[] {1, 1, 1, 1, 1, 1, 1, 1}
      );
    }

    // All code which mathematically finds the best drug is in here. This is
    // done by having a drugScores array, then adding the difference between
    // the drug effect scores and drug scores
    static string FindBestDrug()
    {
      // So (i) iterates through the drugScores, each iteration adding up the
      // differences between each drug effect variable (j) and (i)'s score for this
      int[] drugScores = new int[4] {0, 0, 0, 0};
      for (int i=0; i<4; i++)
      {
        for (int j=0; j<8; j++)
        {
          drugScores[i] += Math.Abs(
            PatientVariableTotals[j] - Drugs[i].Scores[j]
          );
        }
        // drugScores[i] += Math.Abs(PatientVariableTotals[0] -Drugs[i].Scores[0]);
        // drugScores[i] += Math.Abs(PatientVariableTotals[1] -Drugs[i].Scores[1]);
        // drugScores[i] += Math.Abs(PatientVariableTotals[2] -Drugs[i].Scores[2]);
        // drugScores[i] += Math.Abs(PatientVariableTotals[3] -Drugs[i].Scores[3]);
      }

      // A smaller score is better, this means a drug's profile closely matches 
      // the profile generated from the questions
      // TODO: This needs expanding to a sort algorithm, and to consider if
      // 2 drugs are both optimal
      int min = drugScores[0];
      int minIndex = 0;
      for (int i=0; i<4; i++)
      {
        if (drugScores[i] < min)
        {
          min = drugScores[i];
          minIndex = i;
        }
      }

      return Drugs[minIndex].Name;
    }
  }
}
