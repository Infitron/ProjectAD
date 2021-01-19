using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class BookingResponse
    {
        private bluechub_ProjectADContext _context = new bluechub_ProjectADContext();
        IRepository<Artisan> _artisanRepository;
        IRepository<Client> _clientRepository;

        public BookingResponse()
        {
            Quote = new List<Quote>();
            _artisanRepository = new Api.Database.Implementation.Repository<Artisan>(_context);
            _clientRepository = new Api.Database.Implementation.Repository<Client>(_context);
        }
        public int Id { get; set; }
        public int ClienId { get; set; }
        public int ArtisanId { get; set; }

        public string ArtisanFullNmae
        {
            get
            {                
                var artisan = _artisanRepository.GetByAsync(x => x.Id.Equals(this.ArtisanId)).FirstOrDefault();
                return $"{artisan.FirstName} {artisan.LastName}";
            }

        }
        public string ClientFullName
        {
            get
            {
                var client = _clientRepository.GetByAsync(x => x.Id.Equals(this.ClienId)).FirstOrDefault();
                return $"{client?.FirstName ?? "Unavailable"} {client?.LastName ?? "Unavailable"}";
            }
        }
        public string Messages { get; set; }
        public DateTime MsgDate { get; set; }
        public TimeSpan MsgTime { get; set; }
        public int? ServiceId { get; set; }
        public int? QuoteId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Clien { get; set; }
        public List<Quote> Quote { get; set; }
    }
}
