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
    public class TrackController : ApiController
    {
		// GET /api/trac
		public IHttpActionResult GetTracks()
		{
			Remise remise = new Remise();
			remise.SetLoggedInUser("Ferry");

			return Ok(remise.TrackRepos.TrackRepo.Collection.ToList().Select(Mapper.Map<Track, TrackDto>));
		}

		// GET /api/tram/1
		public IHttpActionResult GetTrack(int id)
		{
			Remise remise = new Remise();
			remise.SetLoggedInUser("Ferry");
			Track track = remise.TrackRepos.TrackRepo.Collection.SingleOrDefault(c => c.ID == id);

			if (track == null)
				return NotFound();

			return Ok(Mapper.Map<Track, TrackDto>(track));
		}
	}
}
