using AutoMapper;
using EyeCT4RailsASP.Dtos;
using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EyeCT4RailsASP.Controllers.Api
{
    public class TramController : ApiController
    {
		// GET /api/tram
		public IHttpActionResult GetTrams()
		{
			Remise remise = new Remise();
			remise.SetLoggedInUser("Ferry");

			return Ok(remise.TramRepos.TramRepo.Collection.ToList().Select(Mapper.Map<Tram,TramDto>));
		}

		// GET /api/tram/1
		public IHttpActionResult GetTram(int id)
		{
			Remise remise = new Remise();
			remise.SetLoggedInUser("Ferry");
			Tram tram = remise.TramRepos.TramRepo.Collection.SingleOrDefault(c => c.ID == id);

			if (tram == null)
				return NotFound();

			return Ok(Mapper.Map<Tram,TramDto>(tram));
		}


	}
}
