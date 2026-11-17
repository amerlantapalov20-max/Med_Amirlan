namespace MedicalPortal.Documents;

public abstract class MedicalCertificate : MedicalDocument
{
    protected MedicalCertificate(
        Guid documentId,
        Guid patientId,
        DateTimeOffset issuedAt,
        string issuedBy,
        string purpose,
        DateTimeOffset? validUntil = null)
        : base(documentId, patientId, issuedAt, issuedBy)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(purpose);

        Purpose = purpose;
        ValidUntil = validUntil?.ToUniversalTime();
    }

    public string Purpose { get; }

    public DateTimeOffset? ValidUntil { get; }

    protected override void ValidateDocumentCore()
    {
        if (ValidUntil is { } validUntil && validUntil < IssuedAt)
        {
            throw new InvalidOperationException("Certificate expiry cannot precede its issue date.");
        }
    }
}
