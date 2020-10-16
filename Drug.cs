namespace DrugFinder
{
  class Drug
  {
    public Drug(string name, int scoreA, int scoreB, int scoreC, int scoreD)
    {
      Name = name;
      ScoreA = scoreA;
      ScoreB = scoreB;
      ScoreC = scoreC;
      ScoreD = scoreD;
    }

    public string Name { get; set; }
    public int ScoreA { get; set; }
    public int ScoreB { get; set; }
    public int ScoreC { get; set; }
    public int ScoreD { get; set; }

  }
}