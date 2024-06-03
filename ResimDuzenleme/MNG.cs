using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using ResimDuzenleme.Services.Database;
using ResimDuzenleme.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class MNG : DevExpress.XtraEditors.XtraForm
    {
        private readonly Context _context;
        private readonly DbContextRepository<CargoBarcode> _repository;

        public MNG(Context context, DbContextRepository<CargoBarcode> repository)
        {
            _repository = repository;   
            _context = context; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}