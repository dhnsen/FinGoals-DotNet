namespace FinGoals.Models
{
    public class SavingsGoal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool IsComplete { get; set; }
    }
}