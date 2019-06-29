using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIBedminton.DAO;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.Controllers
{
    [RoutePrefix("api/tin-tuc")]
    public class NewsController : ApiController
    {
        #region GET
        // Lay toan bo phan tu hoac mot so phan tu
        /// <summary>
        /// Takes some Users.
        /// </summary>
        /// <param name="number">The number of the Users. Set null for taking all.</param>
        [Route("")]
        [ResponseType(typeof(IEnumerable<NewsDTO>))]
        public IHttpActionResult GetAllUsers(int? number)
        {
            IEnumerable<NewsDTO> ls;
            if (number == null)
                ls = new NewsDAO().List();
            else
                ls = new NewsDAO().List().Take((int)number);
            if (ls == null)
            {
                return NotFound();
            }
            return Ok(ls);
        }
        // Lay mot phan tu
        // GET api/User/5
        [Route("")]
        [ResponseType(typeof(NewsDTO))]
        public IHttpActionResult Get(int id)
        {
            var b = new NewsDAO().Take(id); // Lay phan tu voi id tuong ung
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);
        }
        #endregion

        #region POST
        // Them moi
        [Route("")]
        [ResponseType(typeof(NewsDTO))]
        public IHttpActionResult Post([FromUri]JObject jsonResult)
        {
            if (!ModelState.IsValid)  // Kiem tra tinh hop le cua giu lieu
            {
                return BadRequest(ModelState);
            }
            var x = JsonConvert.DeserializeObject<NewsDTO>(jsonResult.ToString());
            var last = new NewsDAO().Add(x);
            return Ok(last);
        }
        #endregion

        #region PUT
        // Cap nhat
        [Route("")]
        [ResponseType(typeof(NewsDTO))]
        public IHttpActionResult Put([FromBody]JObject jsonResult)
        {
            if (!ModelState.IsValid)  // Kiem tra tinh hop le cua giu lieu
            {
                return BadRequest(ModelState);
            }
            var x = JsonConvert.DeserializeObject<NewsDTO>(jsonResult.ToString()); // Ep kieu Json sang DTO
            var dao = new NewsDAO();
            if (!dao.isExist(x.ID)) // Kiem tra id co hop le khong
            {
                return NotFound();
            }
            dao.Update(x); // Cap nhat
            return Ok();
        }
        #endregion

        #region DELETE
        // Xoa
        // DELETE api/values/5
        [Route("")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Delete(int id)
        {
            var dao = new NewsDAO();
            if (!dao.isExist(id)) // Kiem tra xem id co hop le hay khong
            {
                return NotFound();
            }
            var check = dao.Delete(id); // Kiem tra viec thuc hien Delete
            return Ok(check);
        }
        #endregion
    }
}
