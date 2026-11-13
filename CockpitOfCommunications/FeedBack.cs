using System;

class FeedBack
{
    public int CampainID { get; set; }
    public int UserID { get; set; }
    public int AproverID { get; set; }
    public string? Justification { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedAt { get; set; }

    public FeedBack(int campainID, int userID, int aproverID, string justification, string reason)
    {
        if (campainID <= 0)
            throw new InvalidOperationException("O ID da campanha deve ser um valor positivo.");
        if (userID <= 0)
            throw new InvalidOperationException("O ID do usuário deve ser um valor positivo.");
        if (aproverID <= 0)
            throw new InvalidOperationException("O ID do aprovador deve ser um valor positivo.");
        
        if (string.IsNullOrWhiteSpace(reason))
            throw new InvalidOperationException("A razão do feedback é obrigatória.");
        
        if (string.IsNullOrWhiteSpace(justification))
            throw new InvalidOperationException("A justificativa do feedback é obrigatória.");
        
        CampainID = campainID;
        UserID = userID;
        AproverID = aproverID;
        Justification = justification;
        Reason = reason;
        CreatedAt = DateTime.Now;
    }
}