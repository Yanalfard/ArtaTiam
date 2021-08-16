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

        private MainRepo<TblBanner> _baner;
        private MainRepo<TblConfig> _config;
        private MainRepo<TblContactU> _contactUs;
        private MainRepo<TblNegotiation> _negotiation;
        private MainRepo<TblImage> _image;
        private MainRepo<TblUser> _user;

        public MainRepo<TblBanner> Baner => _baner ??= new MainRepo<TblBanner>(_context);
        public MainRepo<TblConfig> Config => _config ??= new MainRepo<TblConfig>(_context);
        public MainRepo<TblContactU> ContactUs => _contactUs ??= new MainRepo<TblContactU>(_context);
        public MainRepo<TblNegotiation> Negotiation => _negotiation ??= new MainRepo<TblNegotiation>(_context);
        public MainRepo<TblImage> Image => _image ??= new MainRepo<TblImage>(_context);
        public MainRepo<TblUser> User => _user ??= new MainRepo<TblUser>(_context);

        public void Save() => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
