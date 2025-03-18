namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating
{
    public double Rate { get; set; }
    public int Count { get; set; }

    public Rating(double rate, int count)
    {
        Rate = rate;
        Count = count;
    }                
}