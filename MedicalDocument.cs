namespace MedicalPortal.Documents;

public abstract class MedicalDocument
{
    protected MedicalDocument(
        Guid documentId,
        Guid patientId,
        DateTimeOffset issuedAt,
        string issuedBy)
    {
        if (documentId == Guid.Empty)
        {
            throw new ArgumentException("Document ID cannot be empty.", nameof(documentId));
        }

        if (patientId == Guid.Empty)
        {
            throw new ArgumentException("Patient ID cannot be empty.", nameof(patientId));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(issuedBy);

        DocumentId = documentId;
        PatientId = patientId;
        IssuedAt = issuedAt.ToUniversalTime();
        IssuedBy = issuedBy;
    }

    public Guid DocumentId { get; }

    public Guid PatientId { get; }

    public DateTimeOffset IssuedAt { get; }

    public string IssuedBy { get; }

    public abstract string DocumentType { get; }

    public string GenerateContent()
    {
        ValidateDocumentCore();
        return CreateBody();
    }

    protected virtual void ValidateDocumentCore()
    {
    }

    protected abstract string CreateBody();
}
