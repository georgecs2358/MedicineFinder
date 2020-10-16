using System;

namespace DrugFinder
{
  class Program
  {

    // Represents the patient's desired 'Progression Free Survival' Score.
    // Found by summing up all the scores
    public static int TotalDrugEffectScoreA { get; set; } = 0;

    // Represents the patient's desired 'Time to Treatment Failure' Score
    public static int TotalDrugEffectScoreB { get; set; } = 0;

    // Represents the patient's desired 'Liver Impairment' Score
    public static int TotalDrugEffectScoreC { get; set; } = 0;

    // Represents the patient's desired 'Nausea' Score
    public static int TotalDrugEffectScoreD { get; set; } = 0;

    // The total number of questions asked, used to correctly compare the
    // patient's scores with the scientific score for each drug
    public static int NumberQuestionsAsked { get; set; }

    static void Main(string[] args)
    {
      // This will always be initialised at startup; contains the logic code
      // behind asking questions
      QuestionTree questionTree = new QuestionTree();

      Console.Write("\n---------------------------------------------------\n");
      Console.WriteLine(
        FindBestDrug() + " is the best treatment for this patient."
      );
      Console.Write("---------------------------------------------------\n");
    }

    // All code which mathematically finds the best drug is in here. This is
    // done by having score variables 'drug1Score', 'drug2Score' in this case
    static string FindBestDrug()
    {
      Drug drug1 = new Drug(
        "GEFETINIB", 
        3*Program.NumberQuestionsAsked, 
        9*Program.NumberQuestionsAsked,
        5*Program.NumberQuestionsAsked,
        3*Program.NumberQuestionsAsked
      );
      int drug1Score = 0;
      drug1Score += Math.Abs(TotalDrugEffectScoreA - drug1.ScoreA);
      drug1Score += Math.Abs(TotalDrugEffectScoreB - drug1.ScoreB);
      drug1Score += Math.Abs(TotalDrugEffectScoreC - drug1.ScoreC);
      drug1Score += Math.Abs(TotalDrugEffectScoreD - drug1.ScoreD);

      Drug drug2 = new Drug(
        "AFATINIB",
        9*Program.NumberQuestionsAsked,
        3*Program.NumberQuestionsAsked,
        4*Program.NumberQuestionsAsked,
        10*Program.NumberQuestionsAsked
      );
      int drug2Score = 0;
      drug2Score += Math.Abs(TotalDrugEffectScoreA - drug2.ScoreA);
      drug2Score += Math.Abs(TotalDrugEffectScoreB - drug2.ScoreB);
      drug2Score += Math.Abs(TotalDrugEffectScoreC - drug2.ScoreC);
      drug2Score += Math.Abs(TotalDrugEffectScoreD - drug2.ScoreD);

      // A smaller score is better, this means a drug's profile closely matches 
      // the profile generated from the questions
      if (drug1Score < drug2Score)
      {
        return drug1.Name;
      } else if (drug2Score < drug1Score) {
        return drug2.Name;
      } else {
        return "AFATINIB/GEFETINIB (just give the patient either)";
      }
    }
  }
}
