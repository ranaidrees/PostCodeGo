using PostCodeDataAccess.DataAccess;
using PostCodeDataAccess.Models;
using PostCodeDataAccess.Models.Clinic;
using PostCodeDataAccess.Models.General;
using PostCodeDataAccess.Models.School;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PostCodeGo.Controllers
{
    public class PostCodeController : ApiController
    {
        private readonly IDataReader<GeneralDetails> _generalDetailsReader;
        private readonly IDataReader<NHSClinicList> _nHSClinicListReader;
        private readonly IDataReader<SchoolAndNurseryList> _schoolListReader;

        public PostCodeController()
        {
            _generalDetailsReader = new GeneralApiDataReader();
            _nHSClinicListReader = new NHSClinicApiDataReader();
            _schoolListReader = new SchoolApiDataReader();
        }
        /// <summary>
        /// Dependecy injection will be used to initialize the controller. it is helpful for testing purposes
        /// </summary>
        public PostCodeController(IDataReader<GeneralDetails> generalDetailsReader, IDataReader<NHSClinicList> nHSClinicListReader, IDataReader<SchoolAndNurseryList> schoolListReader)
        {
            _generalDetailsReader = generalDetailsReader;
            _nHSClinicListReader = nHSClinicListReader;
            _schoolListReader = schoolListReader;
        }
        
        // GET api/PostCode/IG118PG
        public async Task<PostCodeDetails> Get(string postcode)
        {
            PostCodeDetails postCodeDetails = new PostCodeDetails();
        
            // Check that we have a topic or return empty list
            if (String.IsNullOrEmpty(postcode))
            {
                return null;
            }
            var generalDetailsTask = _generalDetailsReader.GetDetailsAsync(postcode);
            var nHSClinicListTask = _nHSClinicListReader.GetDetailsAsync(postcode);
            var schoolListTask = _schoolListReader.GetDetailsAsync(postcode);
            await Task.WhenAll(generalDetailsTask,nHSClinicListTask,schoolListTask);
            postCodeDetails.GeneralDetails = await generalDetailsTask;
            postCodeDetails.NHSClinicList = await nHSClinicListTask;
            postCodeDetails.SchoolAndNurseryList = await schoolListTask;
            return postCodeDetails;
       }
    }
}
