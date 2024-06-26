﻿using ResimDuzenleme.Ubl;
using System;
using UblDespatch;


namespace ResimDuzenleme.UblCreate
{

    public class DespatchUBL : BaseDespatchUBL
    {


        public DespatchUBL( )
           : base()
        {
            addAdinationalDocRefXslt();
        }



        private void addAdinationalDocRefXslt( )
        {

            var idRef = new DocumentReferenceType();
            idRef.ID = new IDType { Value = Guid.NewGuid().ToString() };
            idRef.IssueDate = new IssueDateType { Value = DateTime.Now };
            idRef.DocumentType = new DocumentTypeType { Value = "XSLT" };
            idRef.Attachment = new AttachmentType();
            idRef.Attachment.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();

            idRef.Attachment.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
            idRef.Attachment.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
            idRef.Attachment.EmbeddedDocumentBinaryObject.filename = baseDespatchUBL.ID.Value.ToString() + ".xslt";
            idRef.Attachment.EmbeddedDocumentBinaryObject.mimeCode = "application/xml";

            idRef.Attachment.EmbeddedDocumentBinaryObject.Value = Convert.FromBase64String(Xslt.xsltGibDespatch);

            docRefList.Add(idRef);
            baseDespatchUBL.AdditionalDocumentReference = docRefList.ToArray();
        }




    }
}