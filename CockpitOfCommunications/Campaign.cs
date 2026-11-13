class Campaign
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Text { get; private set; }
    public CampaignModel Model { get; private set; }
    public CampaignStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? PublicationDate { get; private set; }
    public string? ImageUrl { get; private set; }
    public int UserId { get; private set; }

    public Campaign(string name, string description, string text, CampaignModel model,
        CampaignStatus status, DateTimeOffset? publicationDate, string? imageUrl, int userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text cannot be empty.", nameof(text));

        if (!Enum.IsDefined(typeof(CampaignModel), model))
            throw new ArgumentOutOfRangeException(nameof(model), "Campaign model is invalid.");

        if (!Enum.IsDefined(typeof(CampaignStatus), status))
            throw new ArgumentOutOfRangeException(nameof(status), "Campaign status is invalid.");

        if (userId <= 0)
            throw new ArgumentOutOfRangeException(nameof(userId), "User ID must be greater than zero.");

        if (status == CampaignStatus.Scheduled)
        {
            if (!publicationDate.HasValue)
                throw new ArgumentException("A publication date is required for scheduled campaigns.", nameof(publicationDate));

            if (publicationDate.Value <= DateTimeOffset.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(publicationDate), "Publication date must be in the future.");
        }

        if (imageUrl != null)
        {
            if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out var imageUri) ||
                (imageUri.Scheme != Uri.UriSchemeHttp && imageUri.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Image URL must be an absolute HTTP or HTTPS URL.", nameof(imageUrl));
            }

            imageUrl = imageUri.AbsoluteUri;
        }

        Name = name.Trim();
        Description = description.Trim();
        Text = text.Trim();
        Model = model;
        Status = status;
        CreatedAt = DateTimeOffset.UtcNow;
        PublicationDate = publicationDate;
        ImageUrl = imageUrl;
        UserId = userId;
    }

    public void CreateCampain()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new InvalidOperationException("O nome da campanha é obrigatório.");

        if (string.IsNullOrWhiteSpace(Description))
            throw new InvalidOperationException("A descrição da campanha é obrigatória.");

        if (string.IsNullOrWhiteSpace(Model.ToString()))
            throw new InvalidOperationException("O texto do modelo da campanha é obrigatório.");

        if (UserId <= 0)
            throw new InvalidOperationException("A campanha deve estar associada a um usuário válido.");

        if (PublicationDate != default && PublicationDate < DateTime.Now)
            throw new InvalidOperationException("A data de publicação não pode estar no passado.");

        CreatedAt = DateTime.Now;
        Status = PublicationDate == default ? CampaignStatus.New : CampaignStatus.Scheduled;
    }

    public void EditCAmpain()
    {

    }

    public void DeleteCampain()
    {

    }
}