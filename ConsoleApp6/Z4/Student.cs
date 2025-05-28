public class Student
{
    public string FullName { get; set; }
    public string Faculty { get; set; }
    public int Year { get; set; }
    public decimal MinGrade { get; set; }
 
    public Student(string fullName, string faculty, int year, decimal minGrade)
    {
        FullName = fullName;
        Faculty = faculty;
        Year = year;
        MinGrade = minGrade;
    }
    
 
    public virtual void PromoteToNextYear()
    {
        if (MinGrade >= 3)
            Year++;
    }
 
    public virtual decimal GetScholarship()
    {
        if (MinGrade <= 3)
            return 0;
        if (MinGrade == 4)
            return 200;
        return 300;
    }
 
    public virtual string GetInfo()
    {
        return $"{FullName}, {Faculty}, Курс: {Year}, Мин. оценка: {MinGrade}, Стипендия: {GetScholarship()} грн";
    }

}