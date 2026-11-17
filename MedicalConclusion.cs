namespace MedicalPortal.Documents;

public abstract class MedicalConclusion : MedicalDocument
{
    protected MedicalConclusion(
        Guid documentId,
        Guid patientId,
        DateTimeOffset issuedAt,
        string issuedBy,
        string conclusionText)
        : base(documentId, patientId, issuedAt, issuedBy)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conclusionText);
        ConclusionText = conclusionText;
    }

    public string ConclusionText { get; }

    protected override string CreateBody() => ConclusionText;
}
