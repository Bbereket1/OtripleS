﻿//---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
//----------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OtripleS.Web.Api.Brokers.DateTimes;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.AssignmentAttachments;

namespace OtripleS.Web.Api.Services.AssignmentAttachments
{
    public partial class AssignmentAttachmentService : IAssignmentAttachmentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public AssignmentAttachmentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<AssignmentAttachment> RemoveAssignmentAttachmentByIdAsync(
            Guid assignmentId,
            Guid attachmentId) =>
        TryCatch(async () =>
        {
            ValidateAssignmentAttachmentIds(assignmentId, attachmentId);

            AssignmentAttachment maybeAssignmentAttachment =
                await this.storageBroker.SelectAssignmentAttachmentByIdAsync(assignmentId, attachmentId);

            ValidateStorageAssignmentAttachment(maybeAssignmentAttachment, assignmentId, attachmentId);

            return await this.storageBroker.DeleteAssignmentAttachmentAsync(maybeAssignmentAttachment);
        });

    }
}
