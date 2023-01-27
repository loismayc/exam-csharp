namespace Exam.Models
{
    public class Sale
    {
        public string Name { get; set; }
        public float Amount { get; set; }

        public Sale(string name, float amount)
        {
            Name = name;
            Amount = amount;
        }
    }

}