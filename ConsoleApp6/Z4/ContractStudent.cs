﻿public class ContractStudent : Student
{
    public bool IsContractPaid { get; set; }

    public ContractStudent(string fullName, string faculty, int year, decimal minGrade, bool isContractPaid)
        : base(fullName, faculty, year, minGrade)
    {
        IsContractPaid = isContractPaid;
    }

    public override void PromoteToNextYear()
    {
        if (MinGrade >= 3 && IsContractPaid)
            Year++;
    }

    public override decimal GetScholarship()
    {
        return 0;
    }

    public virtual string ItsContract()
    {
        return "Этот студент контрактник";
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" {ItsContract()}, Оплачено: {IsContractPaid}";
        
    }
}