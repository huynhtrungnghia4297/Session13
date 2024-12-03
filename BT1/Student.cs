class Student
{
    public string studentID;
    public string studentName;
    public double mathScore;
    public double literatureScore;
    public double englishScore;

    public Student(string studentID, string studentName, double mathScore, double literatureScore, double englishScore)
    {
        this.studentID = studentID;
        this.studentName = studentName;
        this.mathScore = mathScore;
        this.literatureScore = literatureScore;
        this.englishScore = englishScore;
    }

    public double AverageScore()
    {
        return (mathScore + literatureScore + englishScore) / 3;
    }

    public string CalculateRank()
    {
        double average = AverageScore();

        if (average < 5)
        {
            return "Yếu";
        }
        else if (average >= 5 && average <= 6.5)
        {
            return "Trung Bình";
        }
        else if (average > 6.5 && average <= 8)
        {
            return "Khá";
        }
        else
        {
            return "Giỏi";
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Student ID: {studentID}");
        Console.WriteLine($"Name: {studentName}");
        Console.WriteLine($"Math Score: {mathScore}");
        Console.WriteLine($"Literature Score: {literatureScore}");
        Console.WriteLine($"English Score: {englishScore}");
        Console.WriteLine($"Average Score: {AverageScore():0.00}");
        Console.WriteLine($"Rank: {CalculateRank()}");
    }
}
