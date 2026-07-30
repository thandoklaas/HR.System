using HR.System.Domain.Common;

namespace HR.System.Domain.entities;
public class Document : BaseEntity
{
    public int DocumentId { get; set; }

    public string DocumentName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string DocumentFormat { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public string StorageProvider { get; set; } = string.Empty;

    public string StoragePath { get; set; } = string.Empty;

    public DateTimeOffset UploadedDate { get; set; }

    //public bool IsDeleted { get; set; }

    // Employee that uploaded the document
    public int? UploadedByEmployeeId { get; set; } 

    public Employee? UploadedByEmployee { get; set; }

    // One document can be attached to many leave requests
    public ICollection<LeaveRequest> LeaveRequests { get; set; }
        = new List<LeaveRequest>();
}
