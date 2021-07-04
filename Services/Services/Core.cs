using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Services.Repositories;

namespace Services.Services
{
    public class Core : IDisposable
    {
        private readonly ArtaTiamContext _context = new ArtaTiamContext();

        private MainRepo<TblConfig> _config;
        private MainRepo<TblContactU> _contactUs;
        private MainRepo<TblNegotiation> _negotiation;

        public MainRepo<TblConfig> Config => _config ??= new MainRepo<TblConfig>(_context);
        public MainRepo<TblContactU> ContactUs => _contactUs ??= new MainRepo<TblContactU>(_context);
        public MainRepo<TblNegotiation> Negotiation => _negotiation ??= new MainRepo<TblNegotiation>(_context);

        public void Save() => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
