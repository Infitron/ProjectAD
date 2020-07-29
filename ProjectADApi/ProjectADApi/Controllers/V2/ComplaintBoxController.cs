using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ComplaintBoxController : ControllerBase
    {
        readonly private IRepository<Complaint> _complaintRepository;
        private readonly IMapper _mapper;

        public ComplaintBoxController(IRepository<Complaint> complaintRepository, IMapper mapper)
        {
            _complaintRepository = complaintRepository;
            _mapper = mapper;
        }
        // GET: api/Complaint
        [HttpGet(ApiRoute.Complaint.GetAll)]
        public async Task<IActionResult> GetAll(int ArtisanId)
        {
            IEnumerable<Complaint> complaints = await _complaintRepository.GetByAsync(x => x.EmailId.Equals(ArtisanId)).ToListAsync();

            if (complaints.Any())
            {
                List<ComplaintResponse> sll = _mapper.Map<List<ComplaintResponse>>(complaints);


                return Ok(new { status = HttpStatusCode.OK, message = sll });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });

        }

        // GET: api/Complaint/5
        [HttpGet(ApiRoute.Complaint.Get)]
        public async Task<IActionResult> GetComplaint(int ComplaintId)
        {
            Complaint complaint = await _complaintRepository.GetByAsync(x => x.EmailId.Equals(ComplaintId)).FirstOrDefaultAsync();

            if (complaint != null)
            {
                ComplaintResponse sll = _mapper.Map<ComplaintResponse>(complaint);


                return Ok(new { status = HttpStatusCode.OK, message = sll });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // POST: api/Complaint
        [HttpPost(ApiRoute.Complaint.Create)]
        public async Task<IActionResult> Post([FromBody] ComplaintRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });
            }

            Complaint newComplaint = _mapper.Map<Complaint>(model);

            Complaint createdComplaint = await _complaintRepository.CreateAsync(newComplaint);
            return CreatedAtAction(nameof(GetComplaint), new { ComplaintId = newComplaint.Id }, new
            {
                status = HttpStatusCode.Created,
                message = _mapper.Map<ComplaintResponse>(createdComplaint)
            });
        }

        // PUT: api/Complaint/5
        [HttpPut(ApiRoute.Complaint.Update)]
        public async Task<IActionResult> Put(int ComplaintId, [FromBody] ComplaintRequest model)
        {
            Complaint complaint = await _complaintRepository.GetByAsync(x => x.EmailId.Equals(ComplaintId)).FirstOrDefaultAsync();

            if (complaint != null)
            {
                complaint.StatusId = model.StatusId;
                var cResponse = await _complaintRepository.UpdateAsync(complaint);

                var Response = _mapper.Map<ComplaintResponse>(cResponse);

                return Ok(new { status = HttpStatusCode.OK, message = cResponse });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
