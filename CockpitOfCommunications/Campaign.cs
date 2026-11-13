using System;

class Campaign
{       
    public string Name { get; set; }
    public string Description { get; set; }
    public string TextModelCampain {get; set; }
    public CampaignModel Model { get; set; }
    public CampaignStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublicationDate { get; set; }
    public string? ImageUrl { get; set;} 
    public int UserID{get; set;}

    public void CreateCampaign()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new InvalidOperationException("O nome da campanha é obrigatório.");

        if (string.IsNullOrWhiteSpace(Description))
            throw new InvalidOperationException("A descrição da campanha é obrigatória.");

        if (string.IsNullOrWhiteSpace(TextModelCampain))
            throw new InvalidOperationException("O texto do modelo da campanha é obrigatório.");

        if (UserID <= 0)
            throw new InvalidOperationException("A campanha deve estar associada a um usuário válido.");

        if (PublicationDate != default && PublicationDate < DateTime.Now)
            throw new InvalidOperationException("A data de publicação não pode estar no passado.");

        CreatedAt = DateTime.Now;
        Status = PublicationDate == default ? CampaignStatus.New : CampaignStatus.Scheduled;
    }

    public void EditCampaign()
    {
        
    }

    public void DeleteCampaign()
    {
        
    }
}