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
using WebAPIBedminton.DTO;

namespace WebAPIBedminton.Controllers
{
    [RoutePrefix("api/ct-hoa-don")]
    public class Bill_DetailsController : ApiController
    {

        #region GET
        // Lay toan bo phan tu hoac mot so phan tu
        /// <summary>
        /// Takes some Users.
        /// </summary>
        /// <param name="number">The number of the Users. Set null for taking all.</param>
        [Route("")]
        [ResponseType(typeof(IEnumerable<Bill_DetailsDTO>))]
        public IHttpActionResult GetAllUsers(int? number)
        {
            IEnumerable<Bill_DetailsDTO> ls;
            if (number == null)
                ls = new Bill_DetailsDAO().List();
            else
                ls = new Bill_DetailsDAO().List().Take((int)number);
            if (ls == null)
            {
                return NotFound();
            }
            return Ok(ls);
        }
        // Lay mot phan tu
        // GET api/User/5
        [Route("")]
        [ResponseType(typeof(Bill_DetailsDTO))]
        public IHttpActionResult Get(int id)
        {
            var b = new Bill_DetailsDAO().Take(id); // Lay phan tu voi id tuong ung
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
        [ResponseType(typeof(Bill_DetailsDTO))]
        public IHttpActionResult Post([FromUri]JObject jsonResult)
        {
            if (!ModelState.IsValid)  // Kiem tra tinh hop le cua giu lieu
            {
                return BadRequest(ModelState);
            }
            var x = JsonConvert.DeserializeObject<Bill_DetailsDTO>(jsonResult.ToString());
            var last = new Bill_DetailsDAO().Add(x);
            return Ok(last);
        }
        #endregion



        #region DELETE
        // Xoa
        // DELETE api/values/5
        [Route("")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Delete(int idProduct, int idBill)
        {
            var dao = new Bill_DetailsDAO();
            if (!dao.isExist(idProduct,idBill)) // Kiem tra xem id co hop le hay khong
            {
                return NotFound();
            }
            var check = dao.Delete(idProduct,idBill); // Kiem tra viec thuc hien Delete
            return Ok(check);
        }
        #endregion
    }
}
