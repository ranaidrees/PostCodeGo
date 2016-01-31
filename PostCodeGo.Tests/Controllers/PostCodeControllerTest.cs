using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostCodeGo;
using PostCodeGo.Controllers;
using PostCodeDataAccess.DataAccess;
using System.Threading.Tasks;
using PostCodeDataAccess.Models;
using PostCodeDataAccess.Models.General;
using Moq;

namespace PostCodeGo.Tests.Controllers
{
    [TestClass]
    public class PostCodeControllerTest
    {
        [TestMethod]
        public async Task GetPostCodeDetails_ShouldNotFindDetails()
        {
            //Arrange
            PostCodeController controller = new PostCodeController(new GeneralApiDataReader(),new NHSClinicApiDataReader(), new SchoolApiDataReader());

            // Act
            var result = await controller.Get("IG118PG");

            // Assert
            Assert.IsNotNull(result);
        }
        
        private PostCodeDetails GetTestPostCodeDetails()
        {
            ///ToDo: Need to arrange the mock data to do further testing.
            var postCodeDetails = new PostCodeDetails();
            var mockGeneralApiDataReader = new Mock<GeneralApiDataReader>();
            mockGeneralApiDataReader.Object.GetDetailsAsync("");
            postCodeDetails.GeneralDetails = new GeneralDetails { };
            return postCodeDetails;
        }
    }
}
