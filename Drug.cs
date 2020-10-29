namespace DrugFinder
{
  class Drug
  {
    public Drug(string name, int[] scores)
    {
      Name = name;
      Scores = scores;
    }

    public string Name { get; set; }
    public int[] Scores { get; set; }
  }
}