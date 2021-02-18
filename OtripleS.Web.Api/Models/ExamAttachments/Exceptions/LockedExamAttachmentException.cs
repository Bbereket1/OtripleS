﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Models.ExamAttachments.Exceptions
{
    public class LockedExamAttachmentException : Exception
    {
        public LockedExamAttachmentException(Exception innerException)
          : base("Locked Exam Attachment record exception, please try again later.", innerException) { }
    }
}
