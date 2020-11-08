using System;

namespace DrugFinder
{
  class Program
  {
    // Represents the patient's desired score for:
    // [0] Progression-free survival
    // [1] Time to treatment failure
    // [2] Medium overall survival
    // [3] Objective response rate
    // [4] Grade 3/4 adverse reactions
    // [5] Grade 5 adverse reactions
    // [6] Drug discontinuation
    // [7] Hepatic toxicity
    // [8] Treatment related death
    public static double[] PatientVariableTotals { get; set; } = new double[9];

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

      while (NumberAsked < QuestionBank.Questions.Count)
      {
        Console.WriteLine("\n");
        Console.WriteLine(QuestionBank.Questions[NumberAsked].Title);
        int i=0;
        while (i < QuestionBank.Questions[NumberAsked].ResponseText.Length)
        {
          Console.WriteLine(QuestionBank.Questions[NumberAsked].ResponseText[i]);
          i++;
        }
        Console.WriteLine("Please enter a number corresponding to one of the options above.");
        Console.Write("Your selection: ");

        string stringResponse = Console.ReadLine();
        int response = Int32.Parse(stringResponse);
        if (QuestionBank.Questions[NumberAsked].ValidateResponse(response))
        {
          QuestionBank.Questions[NumberAsked].Response = response;
        }
        else 
        {
          // TODO: Use a while loop to keep prompting the user
          QuestionBank.Questions[NumberAsked].Response = 0;
          Console.WriteLine("You have made an invalid selection; (0) was automatically chosen.");
        }
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
        new int[] {77, 0, 23, 45, 9, 100, 97, 90, 80}
      );
      Drugs[1] = new Drug(
        "AFATINIB",
        new int[] {99, 40, 4, 7, 89, 43, 98, 9, 100}
      );
      Drugs[2] = new Drug(
        "OSIMERTINIB",
        new int[] {39, 84, 91, 100, 45, 5, 3, 8, 10}
      );
      Drugs[3] = new Drug(
        "ERLOTINIB",
        new int[] {2, 20, 7, 66, 45, 48, 52, 27, 50}
      );
    }

    // All code which mathematically finds the best drug is in here. This is
    // done by having a drugScores array, then adding the difference between
    // the drug effect scores and drug scores
    static string FindBestDrug()
    {
      double[] drugScores = new double[4] {0, 0, 0, 0};

      // Need to increase PVTs to be out of 100, not 80
      for (int k=0; k<PatientVariableTotals.Length; k++)
      {
        PatientVariableTotals[k] = PatientVariableTotals[k]*1.25;
        Console.WriteLine("PV {0} Total: " + PatientVariableTotals[k], k);
      }
      // So (i) iterates through the drugScores, so we do the following for each
      // of the 4 drugs
      for (int i=0; i<Drugs.Length; i++)
      {
        // Add up the differences between each drug effect variable (j) and 
        // (i)'s score for this
        for (int j=0; j<PatientVariableTotals.Length; j++)
        {
          drugScores[i] += Math.Abs(
            PatientVariableTotals[j] - Drugs[i].Scores[j]
          );
        }
        Console.WriteLine("Drug {0} match score: " + drugScores[i], i);
      }
      Console.WriteLine("\n");
      
      // A smaller score is better, this means a drug's profile closely matches 
      // the profile generated from the questions
      // TODO: This needs expanding to a sort algorithm, and to consider if
      // 2 drugs are both optimal
      double min = drugScores[0];
      int minIndex = 0;
      for (int i=0; i<Drugs.Length; i++)
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
