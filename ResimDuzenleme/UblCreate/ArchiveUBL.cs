﻿using ResimDuzenleme.Operations;
using ResimDuzenleme.Ubl;
using System;
using UblInvoice;

namespace ResimDuzenleme.UblCreate
{
    public class ArchiveUBL : BaseInvoiceUBL
    {



        public ArchiveUBL( )
            : base()
        {
            addAdinationalDocRefXslt();
            createArhiveUbl();
        }



        private void addAdinationalDocRefXslt( )
        {
            var idRef = new DocumentReferenceType();
            idRef.ID = new IDType { Value = Guid.NewGuid().ToString() };
            idRef.IssueDate = baseInvoiceUBL.IssueDate;
            idRef.DocumentType = new DocumentTypeType { Value = nameof(EI.DocumentType.XSLT) };
            idRef.Attachment = new AttachmentType();
            idRef.Attachment.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();
            idRef.Attachment.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
            idRef.Attachment.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
            idRef.Attachment.EmbeddedDocumentBinaryObject.filename = baseInvoiceUBL.ID.Value.ToString() + ".xslt";
            idRef.Attachment.EmbeddedDocumentBinaryObject.mimeCode = "application/xml";
            idRef.Attachment.EmbeddedDocumentBinaryObject.Value = Convert.FromBase64String(Xslt.xsltGibArchive);

            docRefList.Add(idRef);
            baseInvoiceUBL.AdditionalDocumentReference = docRefList.ToArray();
        }


        /// <summary>
        /// e-Arşiv UBL de fatura ye ek olarak eklenecek alanların eklenmesi
        /// </summary>
        private void createArhiveUbl( )
        {
            addAdditionalDocumentReference();
        }

    }
}
