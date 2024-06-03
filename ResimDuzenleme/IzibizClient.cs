using ResimDuzenleme.Adapter;

namespace ResimDuzenleme
{
    public class ResimDuzenlemeClient
    {
        private readonly AuthAdapter _authAdapter;
        private readonly EInvoiceAdapter _eInvoiceAdapter;
        private readonly EArchiveInvoiceAdapter _eInvoiceArchiveAdapter;
        private readonly EDespatchAdapter _eDespatchAdapter;
        private readonly CreditNoteAdapter _creditNoteAdapter;
        private readonly SmmAdapter _smmAdapter;

        public ResimDuzenlemeClient( )
        {
            _authAdapter = new AuthAdapter();
            _eInvoiceAdapter = new EInvoiceAdapter();
            _eInvoiceArchiveAdapter = new EArchiveInvoiceAdapter();
            _eDespatchAdapter = new EDespatchAdapter();
            _creditNoteAdapter = new CreditNoteAdapter();
            _smmAdapter = new SmmAdapter();

        }


        public AuthAdapter Auth( )
        {
            return _authAdapter;
        }

        public EInvoiceAdapter EInvoice( )
        {
            return _eInvoiceAdapter;
        }
        public EArchiveInvoiceAdapter EInvoiceArchive( )
        {
            return _eInvoiceArchiveAdapter;
        }
        public EDespatchAdapter EDespatch( )
        {
            return _eDespatchAdapter;
        }

        public CreditNoteAdapter CreditNote( )
        {
            return _creditNoteAdapter;
        }

        public SmmAdapter Smm( )
        {
            return _smmAdapter;
        }


    }
}
